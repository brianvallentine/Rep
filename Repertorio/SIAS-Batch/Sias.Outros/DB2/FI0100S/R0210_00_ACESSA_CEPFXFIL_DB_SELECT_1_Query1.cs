using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FI0100S
{
    public class R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1 : QueryBasis<R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :WHOST-QTDE:VIND-QTDE
            FROM SEGUROS.CEPFAIXAFILIAL
            WHERE :V1FAVO-CEP BETWEEN CEP_INICIAL AND CEP_FINAL
            AND DATA_TER_VIGENCIA > :V1SIST-DTMOVABE
            AND COD_EMPRESA = :CEPFXFIL-COD-EMPRESA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.CEPFAIXAFILIAL
											WHERE '{this.V1FAVO_CEP}' BETWEEN CEP_INICIAL AND CEP_FINAL
											AND DATA_TER_VIGENCIA > '{this.V1SIST_DTMOVABE}'
											AND COD_EMPRESA = '{this.CEPFXFIL_COD_EMPRESA}'";

            return query;
        }
        public string WHOST_QTDE { get; set; }
        public string VIND_QTDE { get; set; }
        public string CEPFXFIL_COD_EMPRESA { get; set; }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1FAVO_CEP { get; set; }

        public static R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1 Execute(R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1 r0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1)
        {
            var ths = r0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0210_00_ACESSA_CEPFXFIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_QTDE = result[i++].Value?.ToString();
            dta.VIND_QTDE = string.IsNullOrWhiteSpace(dta.WHOST_QTDE) ? "-1" : "0";
            return dta;
        }

    }
}