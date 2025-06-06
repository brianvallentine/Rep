using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0816B
{
    public class R0210_00_SELECT_GE403_DB_SELECT_1_Query1 : QueryBasis<R0210_00_SELECT_GE403_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDLG
            ,NUM_NOSSO_NUMERO_SAP
            INTO :GE403-NUM-IDLG:VIND-NULL01
            ,:GE403-NUM-NOSSO-NUMERO-SAP:VIND-NULL02
            FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
            WHERE NUM_NOSSO_NUMERO_SAP =
            (:V0MOVC-NOSSO-TITULO + 140000000000000000)
            AND COD_SITUACAO = 'F'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_IDLG
											,NUM_NOSSO_NUMERO_SAP
											FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB
											WHERE NUM_NOSSO_NUMERO_SAP =
											('{this.V0MOVC_NOSSO_TITULO}' + 140000000000000000)
											AND COD_SITUACAO = 'F'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string GE403_NUM_IDLG { get; set; }
        public string VIND_NULL01 { get; set; }
        public string GE403_NUM_NOSSO_NUMERO_SAP { get; set; }
        public string VIND_NULL02 { get; set; }
        public string V0MOVC_NOSSO_TITULO { get; set; }

        public static R0210_00_SELECT_GE403_DB_SELECT_1_Query1 Execute(R0210_00_SELECT_GE403_DB_SELECT_1_Query1 r0210_00_SELECT_GE403_DB_SELECT_1_Query1)
        {
            var ths = r0210_00_SELECT_GE403_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0210_00_SELECT_GE403_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0210_00_SELECT_GE403_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE403_NUM_IDLG = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.GE403_NUM_IDLG) ? "-1" : "0";
            dta.GE403_NUM_NOSSO_NUMERO_SAP = result[i++].Value?.ToString();
            dta.VIND_NULL02 = string.IsNullOrWhiteSpace(dta.GE403_NUM_NOSSO_NUMERO_SAP) ? "-1" : "0";
            return dta;
        }

    }
}