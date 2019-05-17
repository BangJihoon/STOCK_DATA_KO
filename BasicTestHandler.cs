using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YuantaCOMLib;


namespace YOACOMClientCSharp
{
    class BasicTestHandler
    {
        public MainForm m_mainForm;
        public IYuantaAPI m_iYuantaAPI;
        public Dictionary<int, string> m_mapRequestTR = new Dictionary<int, string>();
        public Dictionary<int, string> m_mapAutoTR = new Dictionary<int, string>();
        public string m_strJongCode;

        public BasicTestHandler()
        {
            m_mainForm = null;
            m_iYuantaAPI = null;


            m_strJongCode = "";
        }

        public void Search()
        {
            m_strJongCode = m_mainForm.txtBTJongCode.Text;
            m_strJongCode.Trim();
            int nErr = m_iYuantaAPI.YOA_SetTRInfo("300001", "InBlock1");
            nErr = m_iYuantaAPI.YOA_SetFieldString("jang", "1", 0);
            nErr = m_iYuantaAPI.YOA_SetFieldString("jongcode", m_strJongCode, 0);   // i로 수정함
            nErr = m_iYuantaAPI.YOA_SetFieldString("outflag", "N", 0);
            nErr = m_iYuantaAPI.YOA_SetFieldString("tsflag", "0", 0);

            int nReqID = m_iYuantaAPI.YOA_Request("300001", true, -1);

            if (CommDef.ERROR_MAX_CODE < nReqID)
            {
                m_mapRequestTR[nReqID] = "300001";
                m_mainForm.lbLog.Items.Insert(0, "[300001]주식현재가 조회를 요청하였습니다.");
            }
            //Console.WriteLine("1");

        }
        public void RegistAuto()
        {
            // UnRegistAuto();

            m_iYuantaAPI.YOA_SetTRFieldString("11", "InBlock1", "jongcode", m_strJongCode, 0);      //m_mainForm.txtBTJongCode.Text를 i로 바꿈
            int nReqID = m_iYuantaAPI.YOA_RegistAuto("11");

            if (CommDef.ERROR_MAX_CODE < nReqID)
            {
                m_mapAutoTR[nReqID] = "11";

                m_mainForm.btnBTAutoUnRegist.Enabled = true;

                m_mainForm.lbLog.Items.Insert(0, "[11]주식 실시간체결 Auto가 등록 되었습니다.");
                //Console.WriteLine("3");

            }
        }
        public void UnRegistAuto()
        {
            foreach (KeyValuePair<int, string> autoTR in m_mapAutoTR)
            {
                int nResult = m_iYuantaAPI.YOA_UnRegistAutoWithReqID(autoTR.Key);

                if (CommDef.RESULT_SUCCESS == nResult)
                {
                    m_mainForm.btnBTAutoUnRegist.Enabled = true;

                    m_mainForm.lbLog.Items.Insert(0, "[11]주식 실시간체결 Auto가 해지 되었습니다.");
                }
                else
                {
                    m_mainForm.lbLog.Items.Insert(0, "[11]주식 실시간체결 Auto 해지가 실패하였습니다.");

                    string strMsg = m_iYuantaAPI.YOA_GetErrorMessage(nResult);     // 실시간 해지 실패에 대한 메시지를 얻을 수 있습니다.
                    m_mainForm.lbLog.Items.Insert(0, strMsg);
                }
            }

            m_mapAutoTR.Clear();
        }

        public void ReceiveError(int nReqID, int nErrCode, string strErrMsg)
        {
            string strTRID = m_mapRequestTR[nReqID];
            string strName = "";
            if (strTRID.Equals("300001"))
            {
                strName = "[300001]주식현재가 ";
            }

            if (nErrCode == CommDef.ERROR_TIMEOUT_DATA)
            {
                m_mainForm.lbLog.Items.Insert(0, "Timeout " + strName + "요청의 응답이 없습니다.");
            }
            else if (nErrCode == CommDef.ERROR_REQUEST_FAIL)
            {
                //m_mainForm.lbLog.Items.Insert(0, strName + m_iYuantaAPI.YOA_GetErrorMessage(nErrCode));       // 많은 종목에 대해서 최초수신시에 dso 요청실패 오류가 뜸 - 잠시 주석처리
            }
        }

        public void ReceiveData(int nReqID)
        {
            string strTRID = m_mapRequestTR[nReqID];
            if (-1 != strTRID.CompareTo("300001"))
            {
                m_mainForm.txtBTJongName.Text = m_iYuantaAPI.YOA_GetTRFieldString("300001", "OutBlock1", "jongname", 0);    // GetTRFieldString 은 set,get동시
                m_mainForm.txtBTCurJuka.Text = m_iYuantaAPI.YOA_GetTRFieldString("300001", "OutBlock1", "curjuka", 0);
                m_iYuantaAPI.YOA_SetTRInfo("300001", "OutBlock1");  // SetTRInfo -> GetFieldString 값 접근
                m_mainForm.txtBTDebi.Text = m_iYuantaAPI.YOA_GetFieldString("debi", 0);
                m_mainForm.txtBTDebiRate.Text = m_iYuantaAPI.YOA_GetFieldString("debirate", 0);
                m_mainForm.txtBTVolume.Text = m_iYuantaAPI.YOA_GetFieldString("volume", 0);

                m_mainForm.lbLog.Items.Insert(0, "[300001]주식현재가 응답을 수신하였습니다.");
                //Console.WriteLine("2");

            }
        }

        public void ReceiveRealData(int nReqID, string strAutoID)
        {
            if (-1 != strAutoID.CompareTo("11"))
            {
                string strOutCode = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "jongcode", 0);
                strOutCode.Trim();

                if (MainForm.jongCodeList.Contains(m_strJongCode))
                {/*
                    //int nCurJuka = m_iYuantaAPI.YOA_GetTRFieldLong("11", "OutBlock1", "curjuka", 0);
                    m_mainForm.txtBTCurJuka.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "curjuka", 0);
                    m_mainForm.txtBTDebi.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debi", 0);
                    m_mainForm.txtBTDebiRate.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debirate", 0);
                    m_mainForm.txtBTVolume.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "volume", 0);
                    */
                    
                    // 추가부분 - 메인 로그에 정보찍기
                    Console.WriteLine("종목코드 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "jongcode", 0)+"------------------");       // 종목명
                    Console.WriteLine("현재가 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "curjuka", 0));       // 현재가
                    Console.WriteLine("전일대비 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debi", 0));      // 전일대비
                    Console.WriteLine("등락률 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debirate", 0));    // 등락률
                    Console.WriteLine("거래량 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "volume", 0));      // 거래량
                    //Console.WriteLine("4");

                }
            }
        }
    }
}
