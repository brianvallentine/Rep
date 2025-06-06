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
    public class R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1 : QueryBasis<R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_SOLICITA_FATURA
            ( NUM_APOLICE ,
            COD_SUBGRUPO ,
            DATA_SOLICITACAO ,
            DIA_DEBITO ,
            OPCAOPAG ,
            QUANT_VIDAS ,
            CAP_BAS_SEGURADO ,
            PRM_VG ,
            PRM_AP ,
            DTVENCTO_FATURA ,
            COD_FONTE ,
            NUM_TITULO ,
            DT_QUITBCO_TITULO ,
            VALOR_TITULO ,
            SIT_SOLICITA ,
            COD_USUARIO ,
            TIMESTAMP ,
            AGECTADEB ,
            OPRCTADEB ,
            NUMCTADEB ,
            DIGCTADEB )
            VALUES
            ( :VGSOLFAT-NUM-APOLICE ,
            :VGSOLFAT-COD-SUBGRUPO ,
            :VGSOLFAT-DATA-SOLICITACAO ,
            :VGSOLFAT-DIA-DEBITO ,
            :VGSOLFAT-OPCAOPAG ,
            :VGSOLFAT-QUANT-VIDAS ,
            :VGSOLFAT-CAP-BAS-SEGURADO ,
            :VGSOLFAT-PRM-VG ,
            :VGSOLFAT-PRM-AP ,
            :VGSOLFAT-DTVENCTO-FATURA ,
            :VGSOLFAT-COD-FONTE ,
            :VGSOLFAT-NUM-TITULO ,
            :VGSOLFAT-DT-QUITBCO-TITULO ,
            :VGSOLFAT-VALOR-TITULO ,
            :VGSOLFAT-SIT-SOLICITA ,
            :VGSOLFAT-COD-USUARIO ,
            CURRENT TIMESTAMP ,
            :VGSOLFAT-AGECTADEB ,
            :VGSOLFAT-OPRCTADEB ,
            :VGSOLFAT-NUMCTADEB ,
            :VGSOLFAT-DIGCTADEB )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_SOLICITA_FATURA ( NUM_APOLICE , COD_SUBGRUPO , DATA_SOLICITACAO , DIA_DEBITO , OPCAOPAG , QUANT_VIDAS , CAP_BAS_SEGURADO , PRM_VG , PRM_AP , DTVENCTO_FATURA , COD_FONTE , NUM_TITULO , DT_QUITBCO_TITULO , VALOR_TITULO , SIT_SOLICITA , COD_USUARIO , TIMESTAMP , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB ) VALUES ( {FieldThreatment(this.VGSOLFAT_NUM_APOLICE)} , {FieldThreatment(this.VGSOLFAT_COD_SUBGRUPO)} , {FieldThreatment(this.VGSOLFAT_DATA_SOLICITACAO)} , {FieldThreatment(this.VGSOLFAT_DIA_DEBITO)} , {FieldThreatment(this.VGSOLFAT_OPCAOPAG)} , {FieldThreatment(this.VGSOLFAT_QUANT_VIDAS)} , {FieldThreatment(this.VGSOLFAT_CAP_BAS_SEGURADO)} , {FieldThreatment(this.VGSOLFAT_PRM_VG)} , {FieldThreatment(this.VGSOLFAT_PRM_AP)} , {FieldThreatment(this.VGSOLFAT_DTVENCTO_FATURA)} , {FieldThreatment(this.VGSOLFAT_COD_FONTE)} , {FieldThreatment(this.VGSOLFAT_NUM_TITULO)} , {FieldThreatment(this.VGSOLFAT_DT_QUITBCO_TITULO)} , {FieldThreatment(this.VGSOLFAT_VALOR_TITULO)} , {FieldThreatment(this.VGSOLFAT_SIT_SOLICITA)} , {FieldThreatment(this.VGSOLFAT_COD_USUARIO)} , CURRENT TIMESTAMP , {FieldThreatment(this.VGSOLFAT_AGECTADEB)} , {FieldThreatment(this.VGSOLFAT_OPRCTADEB)} , {FieldThreatment(this.VGSOLFAT_NUMCTADEB)} , {FieldThreatment(this.VGSOLFAT_DIGCTADEB)} )";

            return query;
        }
        public string VGSOLFAT_NUM_APOLICE { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_DATA_SOLICITACAO { get; set; }
        public string VGSOLFAT_DIA_DEBITO { get; set; }
        public string VGSOLFAT_OPCAOPAG { get; set; }
        public string VGSOLFAT_QUANT_VIDAS { get; set; }
        public string VGSOLFAT_CAP_BAS_SEGURADO { get; set; }
        public string VGSOLFAT_PRM_VG { get; set; }
        public string VGSOLFAT_PRM_AP { get; set; }
        public string VGSOLFAT_DTVENCTO_FATURA { get; set; }
        public string VGSOLFAT_COD_FONTE { get; set; }
        public string VGSOLFAT_NUM_TITULO { get; set; }
        public string VGSOLFAT_DT_QUITBCO_TITULO { get; set; }
        public string VGSOLFAT_VALOR_TITULO { get; set; }
        public string VGSOLFAT_SIT_SOLICITA { get; set; }
        public string VGSOLFAT_COD_USUARIO { get; set; }
        public string VGSOLFAT_AGECTADEB { get; set; }
        public string VGSOLFAT_OPRCTADEB { get; set; }
        public string VGSOLFAT_NUMCTADEB { get; set; }
        public string VGSOLFAT_DIGCTADEB { get; set; }

        public static void Execute(R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1 r0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1)
        {
            var ths = r0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0854_2600_TRATA_VGSOLFAT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}