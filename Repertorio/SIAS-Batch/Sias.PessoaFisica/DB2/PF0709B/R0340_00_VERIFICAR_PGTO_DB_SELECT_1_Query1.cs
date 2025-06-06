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
    public class R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1 : QueryBasis<R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PARCELA
            INTO :DCLPARCELAS-VIDAZUL.NUM-PARCELA
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO =
            :DCLPARCELAS-VIDAZUL.NUM-CERTIFICADO
            AND NUM_PARCELA >=
            :DCLPARCELAS-VIDAZUL.NUM-PARCELA
            AND SIT_REGISTRO =
            :DCLPARCELAS-VIDAZUL.SIT-REGISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PARCELA
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO =
											'{this.NUM_CERTIFICADO}'
											AND NUM_PARCELA >=
											'{this.NUM_PARCELA}'
											AND SIT_REGISTRO =
											'{this.SIT_REGISTRO}'
											WITH UR";

            return query;
        }
        public string NUM_PARCELA { get; set; }
        public string NUM_CERTIFICADO { get; set; }
        public string SIT_REGISTRO { get; set; }

        public static R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1 Execute(R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1 r0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1)
        {
            var ths = r0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0340_00_VERIFICAR_PGTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}