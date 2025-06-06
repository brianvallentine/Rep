using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0128B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVIMENTO,
            DATA_MOVIMENTO + 1 DAY
            INTO :HISTSG-DTMOVTO-DTTERVIG,
            :HISTSG-DTMOVTO-1DAY
            FROM SEGUROS.V0HISTSEGVG
            WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE
            AND NUM_ITEM = :SEGURA-NUM-ITEM
            AND OCORR_HISTORICO = :SEGURA-OCORHIST
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVIMENTO
							,
											DATA_MOVIMENTO + 1 DAY
											FROM SEGUROS.V0HISTSEGVG
											WHERE NUM_APOLICE = '{this.PROPVA_NUM_APOLICE}'
											AND NUM_ITEM = '{this.SEGURA_NUM_ITEM}'
											AND OCORR_HISTORICO = '{this.SEGURA_OCORHIST}'";

            return query;
        }
        public string HISTSG_DTMOVTO_DTTERVIG { get; set; }
        public string HISTSG_DTMOVTO_1DAY { get; set; }
        public string PROPVA_NUM_APOLICE { get; set; }
        public string SEGURA_NUM_ITEM { get; set; }
        public string SEGURA_OCORHIST { get; set; }

        public static M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 Execute(M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1)
        {
            var ths = m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1();
            var i = 0;
            dta.HISTSG_DTMOVTO_DTTERVIG = result[i++].Value?.ToString();
            dta.HISTSG_DTMOVTO_1DAY = result[i++].Value?.ToString();
            return dta;
        }

    }
}