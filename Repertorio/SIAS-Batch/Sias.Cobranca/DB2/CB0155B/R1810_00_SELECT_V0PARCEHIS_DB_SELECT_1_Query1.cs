using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0155B
{
    public class R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1 : QueryBasis<R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VAL_OPERACAO)
            INTO :PARCEHIS-VAL-OPERACAO:VIND-ORIGEM
            FROM SEGUROS.PARCELA_HISTORICO
            WHERE BCO_COBRANCA =
            :PARCEHIS-BCO-COBRANCA
            AND AGE_COBRANCA =
            :PARCEHIS-AGE-COBRANCA
            AND NUM_AVISO_CREDITO =
            :PARCEHIS-NUM-AVISO-CREDITO
            AND COD_OPERACAO = 300
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VAL_OPERACAO)
											FROM SEGUROS.PARCELA_HISTORICO
											WHERE BCO_COBRANCA =
											'{this.PARCEHIS_BCO_COBRANCA}'
											AND AGE_COBRANCA =
											'{this.PARCEHIS_AGE_COBRANCA}'
											AND NUM_AVISO_CREDITO =
											'{this.PARCEHIS_NUM_AVISO_CREDITO}'
											AND COD_OPERACAO = 300";

            return query;
        }
        public string PARCEHIS_VAL_OPERACAO { get; set; }
        public string VIND_ORIGEM { get; set; }
        public string PARCEHIS_NUM_AVISO_CREDITO { get; set; }
        public string PARCEHIS_BCO_COBRANCA { get; set; }
        public string PARCEHIS_AGE_COBRANCA { get; set; }

        public static R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1 Execute(R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1 r1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1)
        {
            var ths = r1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1810_00_SELECT_V0PARCEHIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARCEHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.VIND_ORIGEM = string.IsNullOrWhiteSpace(dta.PARCEHIS_VAL_OPERACAO) ? "-1" : "0";
            return dta;
        }

    }
}