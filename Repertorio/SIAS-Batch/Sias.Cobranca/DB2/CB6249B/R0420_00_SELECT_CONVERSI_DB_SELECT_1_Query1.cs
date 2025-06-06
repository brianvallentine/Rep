using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB6249B
{
    public class R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1 : QueryBasis<R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_PROPOSTA_SIVPF
            , A.NUM_SICOB
            INTO :CONVERSI-NUM-PROPOSTA-SIVPF
            , :BILHETE-NUM-BILHETE
            FROM SEGUROS.CONVERSAO_SICOB A
            WHERE A.NUM_PROPOSTA_SIVPF =
            :CONVERSI-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_PROPOSTA_SIVPF
											, A.NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB A
											WHERE A.NUM_PROPOSTA_SIVPF =
											'{this.CONVERSI_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1 Execute(R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1 r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1)
        {
            var ths = r0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0420_00_SELECT_CONVERSI_DB_SELECT_1_Query1();
            var i = 0;
            dta.CONVERSI_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            return dta;
        }

    }
}