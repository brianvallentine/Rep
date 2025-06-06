using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1 : QueryBasis<R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT OCOREND
            INTO :DCLPROPOSTAS-VA.OCOREND
            FROM SEGUROS.PROPOSTAS_VA
            WHERE NUM_CERTIFICADO =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT OCOREND
											FROM SEGUROS.PROPOSTAS_VA
											WHERE NUM_CERTIFICADO =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string OCOREND { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1 Execute(R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1 r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1)
        {
            var ths = r2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2215_00_SELECT_PROPOVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.OCOREND = result[i++].Value?.ToString();
            return dta;
        }

    }
}