using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0709B
{
    public class R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_VENCIMENTO
            INTO :DCLPARCELAS-VIDAZUL.DATA-VENCIMENTO
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO =
            :DCLPARCELAS-VIDAZUL.NUM-CERTIFICADO
            AND NUM_PARCELA =
            :DCLPARCELAS-VIDAZUL.NUM-PARCELA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_VENCIMENTO
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO =
											'{this.NUM_CERTIFICADO}'
											AND NUM_PARCELA =
											'{this.NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string DATA_VENCIMENTO { get; set; }
        public string NUM_CERTIFICADO { get; set; }
        public string NUM_PARCELA { get; set; }

        public static R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1 Execute(R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1 r0350_00_SELECT_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r0350_00_SELECT_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0350_00_SELECT_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.DATA_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}