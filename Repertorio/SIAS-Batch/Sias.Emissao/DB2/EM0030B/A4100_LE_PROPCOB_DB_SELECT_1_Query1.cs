using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class A4100_LE_PROPCOB_DB_SELECT_1_Query1 : QueryBasis<A4100_LE_PROPCOB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT TIPO_COBRANCA
            ,DIA_DEBITO
            INTO :PRCB-TIPO-COBRANCA
            ,:PRCB-DIA-DEBITO
            FROM SEGUROS.V0PROPCOB
            WHERE FONTE = :ENDO-FONTE
            AND NRPROPOS = :ENDO-NRPROPOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TIPO_COBRANCA
											,DIA_DEBITO
											FROM SEGUROS.V0PROPCOB
											WHERE FONTE = '{this.ENDO_FONTE}'
											AND NRPROPOS = '{this.ENDO_NRPROPOS}'
											WITH UR";

            return query;
        }
        public string PRCB_TIPO_COBRANCA { get; set; }
        public string PRCB_DIA_DEBITO { get; set; }
        public string ENDO_NRPROPOS { get; set; }
        public string ENDO_FONTE { get; set; }

        public static A4100_LE_PROPCOB_DB_SELECT_1_Query1 Execute(A4100_LE_PROPCOB_DB_SELECT_1_Query1 a4100_LE_PROPCOB_DB_SELECT_1_Query1)
        {
            var ths = a4100_LE_PROPCOB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A4100_LE_PROPCOB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A4100_LE_PROPCOB_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRCB_TIPO_COBRANCA = result[i++].Value?.ToString();
            dta.PRCB_DIA_DEBITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}