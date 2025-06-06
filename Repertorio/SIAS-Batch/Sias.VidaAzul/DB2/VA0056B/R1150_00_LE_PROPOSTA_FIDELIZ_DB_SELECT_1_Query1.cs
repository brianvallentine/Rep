using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0056B
{
    public class R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IFNULL(IND_TP_PROPOSTA, ' ' )
            , ORIGEM_PROPOSTA
            INTO :PROPOFID-IND-TP-PROPOSTA
            , :PROPOFID-ORIGEM-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IFNULL(IND_TP_PROPOSTA
							, ' ' )
											, ORIGEM_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOFID_IND_TP_PROPOSTA { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 Execute(R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 r1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_IND_TP_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}