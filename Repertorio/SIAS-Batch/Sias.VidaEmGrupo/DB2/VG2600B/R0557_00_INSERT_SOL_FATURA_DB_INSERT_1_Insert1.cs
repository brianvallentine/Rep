using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1 : QueryBasis<R0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.VG_SOLICITA_FATURA
            VALUES (:VGSOLFAT-NUM-APOLICE ,
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
            CURRENT_TIMESTAMP ,
            :VGSOLFAT-AGECTADEB ,
            :VGSOLFAT-OPRCTADEB ,
            :VGSOLFAT-NUMCTADEB ,
            :VGSOLFAT-DIGCTADEB )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_SOLICITA_FATURA VALUES ({FieldThreatment(this.VGSOLFAT_NUM_APOLICE)} , {FieldThreatment(this.VGSOLFAT_COD_SUBGRUPO)} , {FieldThreatment(this.VGSOLFAT_DATA_SOLICITACAO)} , {FieldThreatment(this.VGSOLFAT_DIA_DEBITO)} , {FieldThreatment(this.VGSOLFAT_OPCAOPAG)} , {FieldThreatment(this.VGSOLFAT_QUANT_VIDAS)} , {FieldThreatment(this.VGSOLFAT_CAP_BAS_SEGURADO)} , {FieldThreatment(this.VGSOLFAT_PRM_VG)} , {FieldThreatment(this.VGSOLFAT_PRM_AP)} , {FieldThreatment(this.VGSOLFAT_DTVENCTO_FATURA)} , {FieldThreatment(this.VGSOLFAT_COD_FONTE)} , {FieldThreatment(this.VGSOLFAT_NUM_TITULO)} , {FieldThreatment(this.VGSOLFAT_DT_QUITBCO_TITULO)} , {FieldThreatment(this.VGSOLFAT_VALOR_TITULO)} , {FieldThreatment(this.VGSOLFAT_SIT_SOLICITA)} , {FieldThreatment(this.VGSOLFAT_COD_USUARIO)} , CURRENT_TIMESTAMP , {FieldThreatment(this.VGSOLFAT_AGECTADEB)} , {FieldThreatment(this.VGSOLFAT_OPRCTADEB)} , {FieldThreatment(this.VGSOLFAT_NUMCTADEB)} , {FieldThreatment(this.VGSOLFAT_DIGCTADEB)} )";

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

        public static void Execute(R0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1 r0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1)
        {
            var ths = r0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0557_00_INSERT_SOL_FATURA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}