using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1 : QueryBasis<R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_OPERACAO, 0),
            VALUE(DTFATUR, '0001-01-01' )
            INTO :WQTD-HIST-CONT,
            :WS-DTFATUR
            FROM SEGUROS.HIST_CONT_PARCELVA
            WHERE NUM_CERTIFICADO = :RELATORI-NUM-CERTIFICADO
            AND NUM_PARCELA = :RELATORI-NUM-PARCELA
            AND COD_OPERACAO BETWEEN 200 AND 299
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_OPERACAO
							, 0)
							,
											VALUE(DTFATUR
							, '0001-01-01' )
											FROM SEGUROS.HIST_CONT_PARCELVA
											WHERE NUM_CERTIFICADO = '{this.RELATORI_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.RELATORI_NUM_PARCELA}'
											AND COD_OPERACAO BETWEEN 200 AND 299
											WITH UR";

            return query;
        }
        public string WQTD_HIST_CONT { get; set; }
        public string WS_DTFATUR { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1 Execute(R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1 r2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1)
        {
            var ths = r2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2600_00_SELECT_HISTCONTABILVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WQTD_HIST_CONT = result[i++].Value?.ToString();
            dta.WS_DTFATUR = result[i++].Value?.ToString();
            return dta;
        }

    }
}