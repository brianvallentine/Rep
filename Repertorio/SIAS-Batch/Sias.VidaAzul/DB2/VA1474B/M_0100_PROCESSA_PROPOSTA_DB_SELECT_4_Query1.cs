using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1474B
{
    public class M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 : QueryBasis<M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PARCELA
            INTO :PARCEVID-NUM-PARCELA
            FROM SEGUROS.PARCELAS_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND SIT_REGISTRO = '1'
            AND DATA_VENCIMENTO >= :SISTEMAS-DTCURINI
            AND DATA_VENCIMENTO <= :SISTEMAS-DTCURREN
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PARCELA
											FROM SEGUROS.PARCELAS_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND SIT_REGISTRO = '1'
											AND DATA_VENCIMENTO >= '{this.SISTEMAS_DTCURINI}'
											AND DATA_VENCIMENTO <= '{this.SISTEMAS_DTCURREN}'";

            return query;
        }
        public string PARCEVID_NUM_PARCELA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string SISTEMAS_DTCURINI { get; set; }
        public string SISTEMAS_DTCURREN { get; set; }

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
            dta.PARCEVID_NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}