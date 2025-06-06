using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0303B
{
    public class M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1 : QueryBasis<M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO, NUM_ENDOSSO
            INTO
            :DTVENCTO-PARCELA,
            :NUM-ENDOSSO
            FROM
            SEGUROS.HIST_CONT_PARCELVA
            WHERE NUM_APOLICE = :NRAPOLICE
            AND NUM_CERTIFICADO = :NRCERTIF
            AND NUM_PARCELA = :NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
							, NUM_ENDOSSO
											FROM
											SEGUROS.HIST_CONT_PARCELVA
											WHERE NUM_APOLICE = '{this.NRAPOLICE}'
											AND NUM_CERTIFICADO = '{this.NRCERTIF}'
											AND NUM_PARCELA = '{this.NRPARCEL}'
											WITH UR";

            return query;
        }
        public string DTVENCTO_PARCELA { get; set; }
        public string NUM_ENDOSSO { get; set; }
        public string NRAPOLICE { get; set; }
        public string NRCERTIF { get; set; }
        public string NRPARCEL { get; set; }

        public static M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1 Execute(M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1 m_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1)
        {
            var ths = m_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1020_SELECT_HISTCONTABIL_DB_SELECT_2_Query1();
            var i = 0;
            dta.DTVENCTO_PARCELA = result[i++].Value?.ToString();
            dta.NUM_ENDOSSO = result[i++].Value?.ToString();
            return dta;
        }

    }
}