using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using YuantaCOMLib;

namespace YOACOMClientCSharp
{
    public partial class MainForm : Form, IYuantaAPIEvents
    {
        IYuantaAPI m_iYuantaAPI;

        // 종목리스트
        //public static string[] jongCodeList = new string[] { "005930", "105560", "207940", "180640","000020" };
        public static string[] jongCodeList = new string[] { "005930", "000250", "000440", "001000", "001540", "001810", "001840", "002230", "002290", "002680", "002800", "003100", "003310", "003380", "003670", "003800", "004650", "004780", "005160", "005290", "005670", "005710", "005860", "005990", "006050", "006140", "006580", "006620", "006730", "006910", "006920", "007330", "007370", "007390", "007530", "007680", "007720", "007770", "007820", "008290", "008370", "008470", "008800", "008830", "009300", "009520", "009620", "009730", "009780", "010170", "010240", "010280", "010470", "011040", "011080", "011320", "011370", "011560", "012340", "012620", "012700", "012790", "012860", "013030", "013120", "013310", "013720", "013810", "013990", "014100", "014190", "014200", "014470", "014570", "014620", "014940", "014970", "015710", "015750", "016100", "016250", "016600", "016670", "016790", "016920", "017000", "017250", "017480", "017510", "017650", "017680", "017890", "018000", "018120", "018290", "018310", "018620", "018680", "018700", "019010", "019210", "019540", "019550", "019570", "019590", "019660", "019770", "019990", "020180", "020400", "020710", "021040", "021045", "021080", "021320", "021650", "021880", "022100", "022220", "023160", "023410", "023440", "023460", "023600", "023760", "023770", "023790", "023890", "023900", "023910", "024060", "024120", "024740", "024800", "024810", "024830", "024840", "024850", "024880", "024910", "024940", "024950", "025320", "025440", "025550", "025770", "025870", "025880", "025900", "025950", "025980", "026040", "026150", "026180", "026910", "027040", "027050", "027360", "027580", "027710", "027830", "028040", "028080", "028150", "028300", "029480", "029960", "030190", "030270", "030350", "030520", "030530", "030960", "031310", "031330", "031390", "031510", "031860", "031980", "032080", "032190", "032280", "032500", "032540", "032580", "032620", "032680", "032685", "032750", "032790", "032800", "032820", "032850", "032860", "032940", "032960", "032980", "033050", "033100", "033110", "033130", "033160", "033170", "033200", "033230", "033290", "033310", "033320", "033340", "033430", "033500", "033540", "033560", "033600", "033640", "033790", "033830", "034230", "034810", "034940", "034950", "035080", "035200", "035290", "035460", "035480", "035600", "035610", "035620", "035760", "035810", "035890", "035900", "036000", "036010", "036030", "036090", "036120", "036170", "036180", "036190", "036200", "036260", "036420", "036480", "036490", "036540", "036560", "036620", "036630", "036640", "036670", "036690", "036710", "036800", "036810", "036830", "036890", "036930", "037030", "037070", "037230", "037330", "037350", "037370", "037400", "037440", "037460", "037760", "037950", "038010", "038060", "038070", "038110", "038160", "038290", "038340", "038390", "038460", "038500", "038530", "038540", "038620", "038680", "038870", "038880", "038950", "039010", "039020", "039030", "039200", "039230", "039240", "039290", "039310", "039340", "039420", "039440", "039560", "039610", "039670", "039740", "039830", "039840", "039860", "039980", "040160", "040300", "040350", "040420", "040610", "040910", "041020", "041140", "041190", "041440", "041460", "041510", "041520", "041590", "041830", "041910", "041920", "041930", "041960", "042000", "042040", "042110", "042370", "042420", "042500", "042510", "042520", "042600", "042940", "043090", "043100", "043150", "043200", "043220", "043260", "043290", "043340", "043360", "043370", "043590", "043610", "043650", "043710", "043910", "044060", "044180", "044340", "044480", "044490", "044780", "044960", "045060", "045100", "045300", "045340", "045390", "045510", "045520", "045660", "045890", "045970", "046070", "046110", "046120", "046140", "046210", "046310", "046390", "046440", "046890", "046940", "046970", "047080", "047310", "047560", "047770", "047820", "047920", "048260", "048410", "048430", "048470", "048530", "048550", "048770", "048830", "048870", "048910", "049070", "049080", "049120", "049180", "049430", "049470", "049480", "049520", "049550", "049630", "049720", "049830", "049950", "049960", "050090", "050110", "050120", "050320", "050540", "050760", "050860", "050890", "050960", "051160", "051360", "051370", "051380", "051390", "051490", "051500", "051780", "051980", "052020", "052190", "052220", "052260", "052300", "052330", "052400", "052420", "052460", "052600", "052670", "052710", "052770", "052790", "052860", "052900", "053030", "053050", "053060", "053110", "053160", "053260", "053270", "053280", "053290", "053300", "053350", "053450", "053580", "053590", "053610", "053620", "053660", "053700", "053800", "053950", "053980", "054040", "054050", "054090", "054180", "054210", "054220", "054300", "054340", "054410", "054450", "054540", "054620", "054630", "054670", "054780", "054800", "054920", "054930", "054940", "054950", "056000", "056080", "056090", "056190", "056360", "056700", "056730", "057030", "057500", "057540", "057680", "057880", "058110", "058220", "058400", "058420", "058450", "058470", "058530", "058610", "058630", "058820", "059090", "059100", "059120", "059210", "060150", "060230", "060240", "060250", "060260", "060280", "060300", "060310", "060370", "060380", "060480", "060540", "060560", "060570", "060590", "060720", "060900", "061040", "061250", "061970", "062860", "063080", "063170", "063440", "063570", "063760", "064090", "064240", "064260", "064290", "064480", "064510", "064520", "064550", "064760", "064800", "064820", "065060", "065130", "065150", "065170", "065350", "065420", "065440", "065450", "065500", "065510", "065530", "065560", "065570", "065620", "065650", "065660", "065680", "065690", "065710", "065770", "065940", "065950", "066110", "066130", "066310", "066360", "066410", "066430", "066590", "066620", "066670", "066700", "066790", "066900", "066910", "066970", "066980", "067000", "067010", "067080", "067160", "067170", "067280", "067290", "067310", "067390", "067570", "067630", "067730", "067770", "067900", "067920", "067990", "068050", "068240", "068330", "068760", "068790", "068930", "068940", "069080", "069110", "069140", "069330", "069410", "069510", "069540", "069920", "070300", "070590", "071200", "071280", "071460", "071670", "071850", "072020", "072470", "072520", "072770", "072870", "072950", "072990", "073010", "073070", "073110", "073190", "073490", "073540", "073560", "073570", "073640", "074430", "074600", "075130", "075970", "076080", "076610", "077280", "077360", "078020", "078070", "078130", "078140", "078150", "078160", "078340", "078350", "078590", "078600", "078650", "078860", "078890", "078940", "079000", "079170", "079190", "079370", "079650", "079810", "079940", "079950", "079960", "079970", "080000", "080010", "080160", "080220", "080420", "080440", "080470", "080520", "080530", "080580", "080720", "081150", "081580", "082210", "082270", "082660", "082800", "082850", "082920", "083310", "083450", "083470", "083500", "083550", "083640", "083650", "083660", "083790", "083930", "084110", "084180", "084370", "084650", "084730", "084990", "085370", "08537M", "085660", "085670", "085810", "085910", "086040", "086060", "086250", "086390", "086450", "086520", "086670", "086820", "086890", "086900", "086960", "086980", "087010", "087260", "087600", "087730", "088130", "088290", "088390", "088800", "088910", "089010", "089030", "089140", "089150", "089230", "089530", "089600", "089790", "089850", "089890", "089970", "089980", "090150", "090360", "090410", "090460", "090470", "090710", "090740", "090850", "091120", "091340", "091440", "091580", "091590", "091700", "091970", "091990", "092040", "092070", "092130", "092300", "092460", "092600", "092730", "092870", "093190", "093320", "093380", "093520", "093640", "093920", "094170", "094190", "094360", "094480", "094820", "094840", "094850", "094860", "094940", "094970", "095190", "095270", "095340", "095500", "095610", "095660", "095700", "095910", "096040", "096240", "096350", "096530", "096610", "096630", "096640", "096690", "096870", "097520", "097780", "097800", "097870", "098120", "098460", "098660", "099190", "099220", "099320", "099410", "099440", "099520", "099750", "100030", "100090", "100120", "100130", "100590", "100660", "100700", "100790", "101000", "101160", "101170", "101240", "101330", "101390", "101400", "101490", "101670", "101680", "101730", "101930", "102120", "102210", "102710", "102940", "103230", "104040", "104200", "104460", "104480", "104540", "104620", "104830", "105330", "105550", "105740", "106080", "106190", "106240", "106520", "108230", "108320", "108380", "108490", "108790", "108860", "109080", "109610", "109740", "109820", "109860", "109960", "110020", "110790", "110990", "111710", "111820", "111870", "112040", "112240", "113810", "114120", "114190", "114450", "114570", "114630", "114810", "115160", "115180", "115310", "115440", "115450", "115480", "115500", "115530", "115570", "115610", "115960", "117670", "117730", "118990", "119500", "119610", "119830", "119850", "119860", "120240", "121440", "121600", "121800", "121850", "121890", "122310", "122350", "122450", "122640", "122690", "122800", "122870", "122990", "123010", "123040", "123260", "123330", "123410", "123420", "123570", "123750", "123840", "123860", "124500", "125210", "126600", "126640", "126700", "126870", "126880", "127120", "127160", "127710", "128540", "128660", "130500", "130580", "130740", "131030", "131090", "131100", "131180", "131220", "131290", "131370", "131390", "131400", "131760", "131970", "133750", "134060", "134580", "134780", "136480", "136510", "136540", "137400", "137940", "137950", "138070", "138080", "138360", "138580", "138610", "138690", "139050", "139670", "140070", "140410", "140520", "140670", "140860", "141000", "141020", "141070", "141080", "142210", "142280", "142760", "143160", "143240", "143540", "144510", "144960", "145020", "147760", "147830", "148140", "148250", "149940", "149950", "149980", "150840", "150900", };


        BasicTestHandler m_basicTestHandler;
        StockSiseHandler m_stockSiseHandler;
        StockOrderHandler m_stockOrderHandler;
        StockAccountHandler m_stockAccountHandler;
        

        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string section, string key, string def,
            StringBuilder retVal, int size, string filePath);
        /*
        [System.Runtime.InteropServices.DllImport("YuantaAPI.dll")]
        private static extern int YuantaAPI();
        */
        public MainForm()
        {
            InitializeComponent();


            // 유안타 오픈 API 기본 설정 ///////////////////////////////
            IConnectionPoint icp;
            IConnectionPointContainer icpc;
            int dwCookie = 0;

            m_iYuantaAPI = new YuantaAPI();
            icpc = (IConnectionPointContainer)m_iYuantaAPI;
            Guid IID_QueryEvents = typeof(IYuantaAPIEvents).GUID;
            icpc.FindConnectionPoint(ref IID_QueryEvents, out icp);
            icp.Advise(this, out dwCookie);
            ////////////////////////////////////////////////////////////

            m_basicTestHandler = new BasicTestHandler();
            m_basicTestHandler.m_mainForm = this;
            m_basicTestHandler.m_iYuantaAPI = m_iYuantaAPI;

            m_stockSiseHandler = new StockSiseHandler();
            m_stockSiseHandler.m_mainForm = this;
            m_stockSiseHandler.m_iYuantaAPI = m_iYuantaAPI;
            m_stockSiseHandler.InitControl();

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 18);
            lvAcctList.SmallImageList = imgList;

            m_stockOrderHandler = new StockOrderHandler();
            m_stockOrderHandler.m_mainForm = this;
            m_stockOrderHandler.m_iYuantaAPI = m_iYuantaAPI;
            m_stockOrderHandler.InitControl();

            m_stockAccountHandler = new StockAccountHandler();
            m_stockAccountHandler.m_mainForm = this;
            m_stockAccountHandler.m_iYuantaAPI = m_iYuantaAPI;
            m_stockAccountHandler.InitControl();

            // 추가
            Initial();
            Login();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (null != m_iYuantaAPI)
                m_iYuantaAPI.YOA_UnInitial();
        }

        #region IYuantaAPIEvents 멤버

        void IYuantaAPIEvents.ReceiveSystemMessage(int nID, string strMsg)
        {
            //MessageBox.Show("[MsgID : " + nID + "] " + strMsg);
            LogMessage(strMsg);

            if (CommDef.NOTIFY_SYSTEM_NEED_TO_RESTART == nID)
            {
                m_iYuantaAPI.YOA_ReStart();
            }

            throw new NotImplementedException();
        }

        void IYuantaAPIEvents.Login(int nResult, string strMsg)
        {
            if (CommDef.RESPONSE_LOGIN_SUCCESS == nResult)
            {
                btnLogout.Enabled = true;
                btnGetAccount.Enabled = true;

                LogMessage("로그인이 완료되었습니다.");
            }
            else
            {
                btnLogin.Enabled = true;
                btnLogout.Enabled = false;
                btnGetAccount.Enabled = false;

                LogMessage("로그인이 실패하였습니다.", CommDef.YOALOG_ERROR);

                if (CommDef.ERROR_TIMEOUT_DATA == nResult)
                {
                    LogMessage("서버로부터 로그인 응답이 없습니다. 다시 시도하여 주십시오.", CommDef.YOALOG_ERROR, false);
                }
                else
                {
                    LogMessage(m_iYuantaAPI.YOA_GetErrorMessage(nResult), CommDef.YOALOG_ERROR, false);
                }
            }

            throw new NotImplementedException();
        }

        void IYuantaAPIEvents.ReceiveError(int nReqID, int nErrCode, string strErrMsg)
        {
            if (m_basicTestHandler.m_mapRequestTR.ContainsKey(nReqID))
            {
                m_basicTestHandler.ReceiveError(nReqID, nErrCode, strErrMsg);
            }
            else if (m_stockSiseHandler.m_mapRequestTR.ContainsKey(nReqID))
            {
                m_stockSiseHandler.ReceiveError(nReqID, nErrCode, strErrMsg);
            }
            else if (m_stockOrderHandler.m_mapRequestTR.ContainsKey(nReqID))
            {
                m_stockOrderHandler.ReceiveError(nReqID, nErrCode, strErrMsg);
            }

            throw new NotImplementedException();
        }

        void IYuantaAPIEvents.ReceiveData(int nReqID, string strDSOID)
        {
            if (m_basicTestHandler.m_mapRequestTR.ContainsKey(nReqID))
            {
                m_basicTestHandler.ReceiveData(nReqID);
            }
            else if (m_stockSiseHandler.m_mapRequestTR.ContainsKey(nReqID))
            {
                m_stockSiseHandler.ReceiveData(nReqID);
            }
            else if (m_stockOrderHandler.m_mapRequestTR.ContainsKey(nReqID))
            {
                m_stockOrderHandler.ReceiveData(nReqID);
            }

            throw new NotImplementedException();
        }

        void IYuantaAPIEvents.ReceiveRealData(int nReqID, string strAutoID)
        {
            if (m_basicTestHandler.m_mapAutoTR.ContainsKey(nReqID))
            {
                m_basicTestHandler.ReceiveRealData(nReqID, strAutoID);
            }
            else if (m_stockSiseHandler.m_mapAutoTR.ContainsKey(nReqID))
            {
                m_stockSiseHandler.ReceiveRealData(nReqID, strAutoID);
            }
            else if (m_stockOrderHandler.m_mapAutoTR.ContainsKey(nReqID))
            {
                m_stockOrderHandler.ReceiveRealData(nReqID, strAutoID);
            }

            throw new NotImplementedException();
        }

        #endregion

        private void LoadUserInfo()
        {
            string strPath = System.Windows.Forms.Application.ExecutablePath;
            strPath = System.IO.Path.GetDirectoryName(strPath);
            strPath = strPath + "\\testlogin.ini";

            StringBuilder strTemp = new StringBuilder(255);
            GetPrivateProfileString("TEST_INFO", "ID", string.Empty, strTemp, 255, strPath);
            txtUserID.Text = strTemp.ToString();

            GetPrivateProfileString("TEST_INFO", "PWD", string.Empty, strTemp, 255, strPath);
            txtUserPW.Text = strTemp.ToString();

            GetPrivateProfileString("TEST_INFO", "CERT_PWD", string.Empty, strTemp, 255, strPath);
            txtCertPW.Text = strTemp.ToString();

            if (0 < txtUserID.Text.Length && 0 < txtUserPW.Text.Length && 0 < txtCertPW.Text.Length)
                Login();
        }

        public void LogMessage(string strMsg, int nType = 0, bool bTimeStamp = true)
        {
            string strLog = "";

            if (true == bTimeStamp)
            {
                DateTime dt = DateTime.Now;

                if (0 == nType)
                {
                    strLog = "[LOG:" + dt.ToString("yyyy-MM-dd hh:mm:ss") + "] " + strMsg;
                }
                else if (1 == nType)
                {
                    strLog = "[ERR:" + dt.ToString("yyyy-MM-dd hh:mm:ss") + "] " + strMsg;
                }
            }
            else
            {
                strLog = "[ERR_MSG] " + strMsg;
            }

            lbMainLog.Items.Add(strLog);
        }

        public string Commify(int nData)
        {
            string strResult = "";
            strResult = string.Format("{0:#,###0}", nData);

            return strResult;
        }

        public string Commify(double dData)
        {
            string strResult = "";
            strResult = string.Format("{0:#,###.##0}", dData);

            return strResult;
        }

        public string Commify(string strData)
        {
            int nData = Convert.ToInt32(strData);
            return Commify(nData);
        }

        private void Initial()
        {
            btnInitial.Enabled = false;

            //string strURL = "simul.tradarglobal.api.com";
            //string strURL = "real.tradarglobal.api.com";
            string strURL = "real.tradar.api.com";
            //string strURL = "simul.tradar.api.com";
            string strPath = "C:\\Users\\Administrator\\Desktop\\유안타증권\\YOASample\\YOACOMClientCSharp\\bin\\Release";

            if (CommDef.RESULT_SUCCESS == m_iYuantaAPI.YOA_Initial(strURL, strPath))
            {
                if (strURL == "real.tradar.api.com" || strURL == "simul.tradarglobal.api.com")
                    // MessageBox.Show("모의투자로 접속합니다.\n모의투자의 계좌비밀번호는 0000입니다.", "알림", MessageBoxButtons.OK);

                btnLogin.Enabled = true;
                txtUserID.Focus();

                LogMessage("유안타 Open API가 초기화되었습니다.");
            }
            else
            {
                btnInitial.Enabled = true;

                LogMessage("유안타 Open API가 초기화에 실패하였습니다.", CommDef.YOALOG_ERROR);
            }
        }

        private void Login()
        {
            int nResult = m_iYuantaAPI.YOA_Login(txtUserID.Text, txtUserPW.Text, txtCertPW.Text);

            if (CommDef.RESULT_SUCCESS == nResult)
            {
                btnLogin.Enabled = false;

                LogMessage("로그인 요청이 되었습니다.");
            }
            else
            {
                btnLogin.Enabled = true;

                LogMessage("로그인 요청이 실패하였습니다.", CommDef.YOALOG_ERROR);
                LogMessage(m_iYuantaAPI.YOA_GetErrorMessage(nResult), CommDef.YOALOG_ERROR, false);
            }
        }

        private void InitAccount()
        {
            lvAcctList.BeginUpdate();

            lvAcctList.Items.Clear();
            m_stockOrderHandler.ClearAccount();
            m_stockAccountHandler.ClearAccount();

            ListViewItem item = null;
            string strAccount = "";
            string strAcctName = "";

            int nCount = m_iYuantaAPI.YOA_GetAccountCount();
            for (int i = 0; i < nCount; i++)
            {
                item = new ListViewItem(Convert.ToString(i + 1));

                strAccount = m_iYuantaAPI.YOA_GetAccount(i);
                if (1 == strAccount.Length % 2)
                {
                    strAccount = strAccount.Insert(5, "-");
                    strAccount = strAccount.Insert(3, "-");
                }
                else
                {
                    strAccount = strAccount.Insert(8, "-");
                    strAccount = strAccount.Insert(4, "-");
                }

                strAcctName = m_iYuantaAPI.YOA_GetAccountInfo(CommDef.ACCOUNT_INFO_NAME, strAccount);

                item.SubItems.Add(strAccount);
                item.SubItems.Add(strAcctName);

                lvAcctList.Items.Add(item);

                m_stockOrderHandler.AddAccount(strAccount, strAcctName);
                m_stockAccountHandler.AddAccount(strAccount, strAcctName);
            }

            if (0 < nCount)
            {
                cbOrdAccount.SelectedIndex = 0;
                cbAcctAccount.SelectedIndex = 0;
            }

            lvAcctList.EndUpdate();
        }

        private void btnInitial_Click(object sender, EventArgs e)
        {
            Initial();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnGetAccount_Click(object sender, EventArgs e)
        {
            InitAccount();
        }

        private void btnBTSearch_Click(object sender, EventArgs e)
        {
            m_basicTestHandler.Search();
        }

        private void btnBTAutoRegist_Click(object sender, EventArgs e)
        {
            m_basicTestHandler.RegistAuto();
        }

        private void btnBTAutoUnRegist_Click(object sender, EventArgs e)
        {
            m_basicTestHandler.UnRegistAuto();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            m_stockSiseHandler.Search();
        }

        private void btnNextSearch_Click(object sender, EventArgs e)
        {
            m_stockSiseHandler.NextSearch();
        }

        private void btnOrdSearch_Click(object sender, EventArgs e)
        {
            m_stockOrderHandler.Search();
        }

        private void tabPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (2 == tabPanel.SelectedIndex || 3 == tabPanel.SelectedIndex)
            {
                if (0 == lvAcctList.Items.Count)
                {
                    if (DialogResult.OK == MessageBox.Show("계좌정보가 없습니다.\n계좌가져오기를 하시겠습니까?", "알림", MessageBoxButtons.OKCancel))
                    {
                        InitAccount();
                    }
                }
            }
        }

        private void cbOrdAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_stockOrderHandler.cbOrdAccount_SelectedIndexChanged();
        }

        private void nudOrdPrice_ValueChanged(object sender, EventArgs e)
        {
            m_stockOrderHandler.nudOrdPrice_ValueChanged();
        }

        private void nudOrdQty_ValueChanged(object sender, EventArgs e)
        {
            m_stockOrderHandler.nudOrdPrice_ValueChanged();
        }

        private void tabMesuMedo_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_stockOrderHandler.SetOrderMedoMesu(tabMesuMedo.SelectedIndex);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            m_stockOrderHandler.Order();
        }

        private void btnOrdSearchMiChegyul_Click(object sender, EventArgs e)
        {
            m_stockOrderHandler.SearchMiChegyul();
        }

        private void btnOrdSearchChegyul_Click(object sender, EventArgs e)
        {
            m_stockOrderHandler.SearchChegyul();
        }

        private void cbAcctAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_stockAccountHandler.cbAcctAccount_SelectedIndexChanged();
        }

        private void btnAcctSearch_Click(object sender, EventArgs e)
        {
            m_stockAccountHandler.Search();
        }


        private void textbtn_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            foreach (string jongCode in jongCodeList)
            {
                txtBTJongCode.Text = jongCode;
                // search
                m_basicTestHandler.m_strJongCode = jongCode;
                int nErr = m_iYuantaAPI.YOA_SetTRInfo("300001", "InBlock1");
                m_iYuantaAPI.YOA_SetFieldString("jang", "1", 0);
                m_iYuantaAPI.YOA_SetFieldString("jongcode", jongCode, 0);   // i로 수정함
                m_iYuantaAPI.YOA_SetFieldString("outflag", "N", 0);
                m_iYuantaAPI.YOA_SetFieldString("tsflag", "0", 0);

                int nReqID = m_iYuantaAPI.YOA_Request("300001", true, -1);

                if (CommDef.ERROR_MAX_CODE < nReqID)
                {
                    m_basicTestHandler.m_mapRequestTR[nReqID] = "300001";
                }
                count++;
                Console.WriteLine("-------------------" + count + "번째 종목 등록-------------------" + jongCode);
                if(count==15)
                    break;              // 종목이 16개 부터 오류가 남
                // ReceiveData
                m_basicTestHandler.ReceiveData(nReqID);
                // auto 등록
                m_basicTestHandler.RegistAuto();
                // ReceiveRealData
                m_basicTestHandler.ReceiveRealData(nReqID, "11");
                
            }
            LogMessage(jongCodeList.Length+ "개 종목이 auto 수신 등록되었습니다.");
        }

        /*

        public void Test1()      // 300001 가져오기 따로땐 코드
        {
            // 300001 요청 ---------------------------------------------------
            string xxx = "005930";

            int nErr = m_iYuantaAPI.YOA_SetTRInfo("11", "InBlock1");

            m_iYuantaAPI.YOA_SetFieldString("jang", "1", 0);

            m_iYuantaAPI.YOA_SetFieldString("jongcode", xxx, 0);   //m_strJongCode를 i로 수정함

            int nReqID = m_iYuantaAPI.YOA_Request("11", true, -1);  // nReqID = 1001


            if (CommDef.ERROR_MAX_CODE < nReqID)
            {
                m_basicTestHandler.m_mapRequestTR[nReqID] = "11";
                Console.WriteLine("[11]주식현재가 조회를 요청하였습니다.");
            }
            // auto 등록 ---------------------------------------------------
            m_iYuantaAPI.YOA_SetTRFieldString("11", "InBlock1", "jongcode", xxx, 0);
            nReqID = m_iYuantaAPI.YOA_RegistAuto("11");

            if (CommDef.ERROR_MAX_CODE < nReqID)
            {
                m_basicTestHandler.m_mapAutoTR[nReqID] = "11";
                Console.WriteLine("[11]주식 실시간체결 Auto가 등록 되었습니다.");
            }
            Delay(1500);     // 1초정도 쉬어줘야 통신됨


            string strOutCode = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "jongcode", 0);
            strOutCode.Trim();

            if (MainForm.jongCodeList.Contains(xxx))
            {

                //int nCurJuka = m_iYuantaAPI.YOA_GetTRFieldLong("11", "OutBlock1", "curjuka", 0);
                m_basicTestHandler.m_mainForm.txtBTCurJuka.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "curjuka", 0);
                m_basicTestHandler.m_mainForm.txtBTDebi.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debi", 0);
                m_basicTestHandler.m_mainForm.txtBTDebiRate.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debirate", 0);
                m_basicTestHandler.m_mainForm.txtBTVolume.Text = m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "volume", 0);


                // 추가부분 - 메인 로그에 정보찍기
                Console.WriteLine("종목명 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "jongcode", 0));       // 종목명
                Console.WriteLine("현재가 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "curjuka", 0));       // 현재가
                Console.WriteLine("전일대비 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debi", 0));      // 전일대비
                Console.WriteLine("등락률 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "debirate", 0));    // 등락률
                Console.WriteLine("거래량 :" + m_iYuantaAPI.YOA_GetTRFieldString("11", "OutBlock1", "volume", 0));      // 거래량        
            }
        }

    */
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
    }
}

// search -> 
// 300001.현재가/300002.현재호가/301004.일자별주가 조회 -> 
// 300001 현재가 폼에 응답 뿌려줌 ->
// 11.체결/12.호가/.. auto등록
