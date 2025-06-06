using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0813B
{
    public class R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1 : QueryBasis<R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_GERACAO
            INTO :V0FITA-DATA-GERACAO
            FROM SEGUROS.V0FITASASSE
            WHERE COD_CONVENIO = :WHOST-CODCONV
            AND NSAS = :V0HCTA-NSAS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_GERACAO
											FROM SEGUROS.V0FITASASSE
											WHERE COD_CONVENIO = '{this.WHOST_CODCONV}'
											AND NSAS = '{this.V0HCTA_NSAS}'
											WITH UR";

            return query;
        }
        public string V0FITA_DATA_GERACAO { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string V0HCTA_NSAS { get; set; }

        public static R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1 Execute(R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1 r1000_00_QUITA_PARCELA_DB_SELECT_8_Query1)
        {
            var ths = r1000_00_QUITA_PARCELA_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_QUITA_PARCELA_DB_SELECT_8_Query1();
            var i = 0;
            dta.V0FITA_DATA_GERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}