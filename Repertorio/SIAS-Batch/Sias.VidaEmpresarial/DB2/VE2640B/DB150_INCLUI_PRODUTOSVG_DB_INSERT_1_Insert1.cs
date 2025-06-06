using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1 : QueryBasis<DB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PRODUTOS_VG
            (NUM_APOLICE ,
            COD_SUBGRUPO ,
            ID_SISTEMA ,
            COD_PRODUTO_AZUL ,
            COD_PRODUTO ,
            NOME_PRODUTO ,
            PERI_PAGAMENTO ,
            DIAS_INICIO_VIGENC ,
            DATA_MINVIGENCIA ,
            DATA_MAXVIGENCIA ,
            SIT_PLANO_CEF ,
            OPCAO_PAGAMENTO ,
            COD_CEDENTE ,
            OPC_AGENCTO_SUREG ,
            OPCAO_CAPITALIZ ,
            COD_SERIE ,
            NUM_SEQ_TITULO ,
            NUM_MALA_DIRETA ,
            RAMO ,
            CANCELA_ANTIGO ,
            IND_RCAP ,
            NRMSCAP ,
            NRMFDCAP ,
            DTMVFDCAP ,
            NRNSAF ,
            NLMSAF ,
            TEM_CDG ,
            PRI_CDG ,
            TEM_SAF ,
            PRI_SAF ,
            CODEMPRSA ,
            NRMATRSA ,
            DTAVERB ,
            COD_RUBRICA ,
            COD_CCT ,
            TRANSF_SUBGRUPO ,
            DIA_FATURA ,
            ARQ_FDCAP ,
            ESTR_COBR ,
            ESTR_EMISS ,
            ORIG_PRODU ,
            COD_AGENCIADOR ,
            MOV_INTERFACE ,
            CONSISTE_MATRIC ,
            RISCO ,
            COD_SEGURADORA ,
            COD_SEGU_SAF ,
            CODRELAT ,
            TEM_FAIXAETA ,
            TEM_IGPM ,
            ROT_SAF ,
            COD_PRODUTO_EA ,
            COBERADIC_PREMIO ,
            CUSTOCAP_TOTAL ,
            DESCONTO_ADESAO)
            VALUES (:PRODUVG-NUM-APOLICE ,
            :PRODUVG-COD-SUBGRUPO ,
            :PRODUVG-ID-SISTEMA ,
            :PRODUVG-COD-PRODUTO-AZUL ,
            :PRODUVG-COD-PRODUTO ,
            :PRODUVG-NOME-PRODUTO ,
            :PRODUVG-PERI-PAGAMENTO ,
            :PRODUVG-DIAS-INICIO-VIGENC ,
            :PRODUVG-DATA-MINVIGENCIA ,
            :PRODUVG-DATA-MAXVIGENCIA ,
            :PRODUVG-SIT-PLANO-CEF ,
            :PRODUVG-OPCAO-PAGAMENTO ,
            :PRODUVG-COD-CEDENTE ,
            :PRODUVG-OPC-AGENCTO-SUREG ,
            :PRODUVG-OPCAO-CAPITALIZ ,
            :PRODUVG-COD-SERIE ,
            :PRODUVG-NUM-SEQ-TITULO ,
            :PRODUVG-NUM-MALA-DIRETA ,
            :PRODUVG-RAMO ,
            :PRODUVG-CANCELA-ANTIGO ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            :PRODUVG-TEM-CDG :N-TEM-CDG,
            NULL ,
            :PRODUVG-TEM-SAF :N-TEM-SAF,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            858 ,
            NULL ,
            NULL ,
            :PRODUVG-DIA-FATURA ,
            NULL ,
            :PRODUVG-ESTR-COBR ,
            :PRODUVG-ESTR-EMISS ,
            :PRODUVG-ORIG-PRODU ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            NULL ,
            :PRODUVG-CODRELAT ,
            NULL ,
            NULL ,
            :PRODUVG-ROT-SAF:N-ROT-SAF,
            :PRODUVG-COD-PRODUTO-EA :N-COD-PROD-EA,
            :PRODUVG-COBERADIC-PREMIO ,
            :PRODUVG-CUSTOCAP-TOTAL ,
            :PRODUVG-DESCONTO-ADESAO)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PRODUTOS_VG (NUM_APOLICE , COD_SUBGRUPO , ID_SISTEMA , COD_PRODUTO_AZUL , COD_PRODUTO , NOME_PRODUTO , PERI_PAGAMENTO , DIAS_INICIO_VIGENC , DATA_MINVIGENCIA , DATA_MAXVIGENCIA , SIT_PLANO_CEF , OPCAO_PAGAMENTO , COD_CEDENTE , OPC_AGENCTO_SUREG , OPCAO_CAPITALIZ , COD_SERIE , NUM_SEQ_TITULO , NUM_MALA_DIRETA , RAMO , CANCELA_ANTIGO , IND_RCAP , NRMSCAP , NRMFDCAP , DTMVFDCAP , NRNSAF , NLMSAF , TEM_CDG , PRI_CDG , TEM_SAF , PRI_SAF , CODEMPRSA , NRMATRSA , DTAVERB , COD_RUBRICA , COD_CCT , TRANSF_SUBGRUPO , DIA_FATURA , ARQ_FDCAP , ESTR_COBR , ESTR_EMISS , ORIG_PRODU , COD_AGENCIADOR , MOV_INTERFACE , CONSISTE_MATRIC , RISCO , COD_SEGURADORA , COD_SEGU_SAF , CODRELAT , TEM_FAIXAETA , TEM_IGPM , ROT_SAF , COD_PRODUTO_EA , COBERADIC_PREMIO , CUSTOCAP_TOTAL , DESCONTO_ADESAO) VALUES ({FieldThreatment(this.PRODUVG_NUM_APOLICE)} , {FieldThreatment(this.PRODUVG_COD_SUBGRUPO)} , {FieldThreatment(this.PRODUVG_ID_SISTEMA)} , {FieldThreatment(this.PRODUVG_COD_PRODUTO_AZUL)} , {FieldThreatment(this.PRODUVG_COD_PRODUTO)} , {FieldThreatment(this.PRODUVG_NOME_PRODUTO)} , {FieldThreatment(this.PRODUVG_PERI_PAGAMENTO)} , {FieldThreatment(this.PRODUVG_DIAS_INICIO_VIGENC)} , {FieldThreatment(this.PRODUVG_DATA_MINVIGENCIA)} , {FieldThreatment(this.PRODUVG_DATA_MAXVIGENCIA)} , {FieldThreatment(this.PRODUVG_SIT_PLANO_CEF)} , {FieldThreatment(this.PRODUVG_OPCAO_PAGAMENTO)} , {FieldThreatment(this.PRODUVG_COD_CEDENTE)} , {FieldThreatment(this.PRODUVG_OPC_AGENCTO_SUREG)} , {FieldThreatment(this.PRODUVG_OPCAO_CAPITALIZ)} , {FieldThreatment(this.PRODUVG_COD_SERIE)} , {FieldThreatment(this.PRODUVG_NUM_SEQ_TITULO)} , {FieldThreatment(this.PRODUVG_NUM_MALA_DIRETA)} , {FieldThreatment(this.PRODUVG_RAMO)} , {FieldThreatment(this.PRODUVG_CANCELA_ANTIGO)} , NULL , NULL , NULL , NULL , NULL , NULL ,  {FieldThreatment((this.N_TEM_CDG?.ToInt() == -1 ? null : this.PRODUVG_TEM_CDG))}, NULL ,  {FieldThreatment((this.N_TEM_SAF?.ToInt() == -1 ? null : this.PRODUVG_TEM_SAF))}, NULL , NULL , NULL , NULL , 858 , NULL , NULL , {FieldThreatment(this.PRODUVG_DIA_FATURA)} , NULL , {FieldThreatment(this.PRODUVG_ESTR_COBR)} , {FieldThreatment(this.PRODUVG_ESTR_EMISS)} , {FieldThreatment(this.PRODUVG_ORIG_PRODU)} , NULL , NULL , NULL , NULL , NULL , NULL , {FieldThreatment(this.PRODUVG_CODRELAT)} , NULL , NULL ,  {FieldThreatment((this.N_ROT_SAF?.ToInt() == -1 ? null : this.PRODUVG_ROT_SAF))},  {FieldThreatment((this.N_COD_PROD_EA?.ToInt() == -1 ? null : this.PRODUVG_COD_PRODUTO_EA))}, {FieldThreatment(this.PRODUVG_COBERADIC_PREMIO)} , {FieldThreatment(this.PRODUVG_CUSTOCAP_TOTAL)} , {FieldThreatment(this.PRODUVG_DESCONTO_ADESAO)})";

            return query;
        }
        public string PRODUVG_NUM_APOLICE { get; set; }
        public string PRODUVG_COD_SUBGRUPO { get; set; }
        public string PRODUVG_ID_SISTEMA { get; set; }
        public string PRODUVG_COD_PRODUTO_AZUL { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string PRODUVG_PERI_PAGAMENTO { get; set; }
        public string PRODUVG_DIAS_INICIO_VIGENC { get; set; }
        public string PRODUVG_DATA_MINVIGENCIA { get; set; }
        public string PRODUVG_DATA_MAXVIGENCIA { get; set; }
        public string PRODUVG_SIT_PLANO_CEF { get; set; }
        public string PRODUVG_OPCAO_PAGAMENTO { get; set; }
        public string PRODUVG_COD_CEDENTE { get; set; }
        public string PRODUVG_OPC_AGENCTO_SUREG { get; set; }
        public string PRODUVG_OPCAO_CAPITALIZ { get; set; }
        public string PRODUVG_COD_SERIE { get; set; }
        public string PRODUVG_NUM_SEQ_TITULO { get; set; }
        public string PRODUVG_NUM_MALA_DIRETA { get; set; }
        public string PRODUVG_RAMO { get; set; }
        public string PRODUVG_CANCELA_ANTIGO { get; set; }
        public string PRODUVG_TEM_CDG { get; set; }
        public string N_TEM_CDG { get; set; }
        public string PRODUVG_TEM_SAF { get; set; }
        public string N_TEM_SAF { get; set; }
        public string PRODUVG_DIA_FATURA { get; set; }
        public string PRODUVG_ESTR_COBR { get; set; }
        public string PRODUVG_ESTR_EMISS { get; set; }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string PRODUVG_CODRELAT { get; set; }
        public string PRODUVG_ROT_SAF { get; set; }
        public string N_ROT_SAF { get; set; }
        public string PRODUVG_COD_PRODUTO_EA { get; set; }
        public string N_COD_PROD_EA { get; set; }
        public string PRODUVG_COBERADIC_PREMIO { get; set; }
        public string PRODUVG_CUSTOCAP_TOTAL { get; set; }
        public string PRODUVG_DESCONTO_ADESAO { get; set; }

        public static void Execute(DB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1 dB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1)
        {
            var ths = dB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB150_INCLUI_PRODUTOSVG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}