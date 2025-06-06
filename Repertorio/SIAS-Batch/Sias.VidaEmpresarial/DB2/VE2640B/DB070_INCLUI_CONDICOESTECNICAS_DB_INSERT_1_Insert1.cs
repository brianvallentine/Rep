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
    public class DB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1 : QueryBasis<DB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CONDICOES_TECNICAS
            ( NUM_APOLICE ,
            COD_SUBGRUPO ,
            QTD_SAL_MORNATU ,
            QTD_SAL_MORACID ,
            QTD_SAL_INVPERM ,
            TAXA_AP_MORACID ,
            TAXA_AP_INVPERM ,
            TAXA_AP_AMDS ,
            TAXA_AP_DH ,
            TAXA_AP_DIT ,
            TAXA_AP ,
            CARREGA_PRINCIPAL ,
            CARREGA_CONJUGE ,
            CARREGA_FILHOS ,
            GARAN_ADIC_IEA ,
            GARAN_ADIC_IPA ,
            GARAN_ADIC_IPD ,
            GARAN_ADIC_HD ,
            TAXA_DESPESA_ADM ,
            TAXA_IRB ,
            LIM_CAP_MORNATU ,
            LIM_CAP_MORACID ,
            LIM_CAP_INVAPER ,
            COD_EMPRESA )
            VALUES
            ( :CONDITEC-NUM-APOLICE ,
            :CONDITEC-COD-SUBGRUPO ,
            :CONDITEC-QTD-SAL-MORNATU ,
            :CONDITEC-QTD-SAL-MORACID ,
            :CONDITEC-QTD-SAL-INVPERM ,
            :CONDITEC-TAXA-AP-MORACID ,
            :CONDITEC-TAXA-AP-INVPERM ,
            :CONDITEC-TAXA-AP-AMDS ,
            :CONDITEC-TAXA-AP-DH ,
            :CONDITEC-TAXA-AP-DIT ,
            :CONDITEC-TAXA-AP ,
            :CONDITEC-CARREGA-PRINCIPAL ,
            :CONDITEC-CARREGA-CONJUGE ,
            :CONDITEC-CARREGA-FILHOS ,
            :CONDITEC-GARAN-ADIC-IEA ,
            :CONDITEC-GARAN-ADIC-IPA ,
            :CONDITEC-GARAN-ADIC-IPD ,
            :CONDITEC-GARAN-ADIC-HD ,
            :CONDITEC-TAXA-DESPESA-ADM ,
            :CONDITEC-TAXA-IRB ,
            :CONDITEC-LIM-CAP-MORNATU ,
            :CONDITEC-LIM-CAP-MORACID ,
            :CONDITEC-LIM-CAP-INVAPER ,
            :CONDITEC-COD-EMPRESA)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONDICOES_TECNICAS ( NUM_APOLICE , COD_SUBGRUPO , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_AP , CARREGA_PRINCIPAL , CARREGA_CONJUGE , CARREGA_FILHOS , GARAN_ADIC_IEA , GARAN_ADIC_IPA , GARAN_ADIC_IPD , GARAN_ADIC_HD , TAXA_DESPESA_ADM , TAXA_IRB , LIM_CAP_MORNATU , LIM_CAP_MORACID , LIM_CAP_INVAPER , COD_EMPRESA ) VALUES ( {FieldThreatment(this.CONDITEC_NUM_APOLICE)} , {FieldThreatment(this.CONDITEC_COD_SUBGRUPO)} , {FieldThreatment(this.CONDITEC_QTD_SAL_MORNATU)} , {FieldThreatment(this.CONDITEC_QTD_SAL_MORACID)} , {FieldThreatment(this.CONDITEC_QTD_SAL_INVPERM)} , {FieldThreatment(this.CONDITEC_TAXA_AP_MORACID)} , {FieldThreatment(this.CONDITEC_TAXA_AP_INVPERM)} , {FieldThreatment(this.CONDITEC_TAXA_AP_AMDS)} , {FieldThreatment(this.CONDITEC_TAXA_AP_DH)} , {FieldThreatment(this.CONDITEC_TAXA_AP_DIT)} , {FieldThreatment(this.CONDITEC_TAXA_AP)} , {FieldThreatment(this.CONDITEC_CARREGA_PRINCIPAL)} , {FieldThreatment(this.CONDITEC_CARREGA_CONJUGE)} , {FieldThreatment(this.CONDITEC_CARREGA_FILHOS)} , {FieldThreatment(this.CONDITEC_GARAN_ADIC_IEA)} , {FieldThreatment(this.CONDITEC_GARAN_ADIC_IPA)} , {FieldThreatment(this.CONDITEC_GARAN_ADIC_IPD)} , {FieldThreatment(this.CONDITEC_GARAN_ADIC_HD)} , {FieldThreatment(this.CONDITEC_TAXA_DESPESA_ADM)} , {FieldThreatment(this.CONDITEC_TAXA_IRB)} , {FieldThreatment(this.CONDITEC_LIM_CAP_MORNATU)} , {FieldThreatment(this.CONDITEC_LIM_CAP_MORACID)} , {FieldThreatment(this.CONDITEC_LIM_CAP_INVAPER)} , {FieldThreatment(this.CONDITEC_COD_EMPRESA)})";

            return query;
        }
        public string CONDITEC_NUM_APOLICE { get; set; }
        public string CONDITEC_COD_SUBGRUPO { get; set; }
        public string CONDITEC_QTD_SAL_MORNATU { get; set; }
        public string CONDITEC_QTD_SAL_MORACID { get; set; }
        public string CONDITEC_QTD_SAL_INVPERM { get; set; }
        public string CONDITEC_TAXA_AP_MORACID { get; set; }
        public string CONDITEC_TAXA_AP_INVPERM { get; set; }
        public string CONDITEC_TAXA_AP_AMDS { get; set; }
        public string CONDITEC_TAXA_AP_DH { get; set; }
        public string CONDITEC_TAXA_AP_DIT { get; set; }
        public string CONDITEC_TAXA_AP { get; set; }
        public string CONDITEC_CARREGA_PRINCIPAL { get; set; }
        public string CONDITEC_CARREGA_CONJUGE { get; set; }
        public string CONDITEC_CARREGA_FILHOS { get; set; }
        public string CONDITEC_GARAN_ADIC_IEA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPA { get; set; }
        public string CONDITEC_GARAN_ADIC_IPD { get; set; }
        public string CONDITEC_GARAN_ADIC_HD { get; set; }
        public string CONDITEC_TAXA_DESPESA_ADM { get; set; }
        public string CONDITEC_TAXA_IRB { get; set; }
        public string CONDITEC_LIM_CAP_MORNATU { get; set; }
        public string CONDITEC_LIM_CAP_MORACID { get; set; }
        public string CONDITEC_LIM_CAP_INVAPER { get; set; }
        public string CONDITEC_COD_EMPRESA { get; set; }

        public static void Execute(DB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1 dB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1)
        {
            var ths = dB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override DB070_INCLUI_CONDICOESTECNICAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}