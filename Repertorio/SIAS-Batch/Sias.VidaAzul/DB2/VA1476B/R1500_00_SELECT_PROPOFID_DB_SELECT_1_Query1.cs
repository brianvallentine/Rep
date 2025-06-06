using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1476B
{
    public class R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IND_TIPO_CONTA
            INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA
            :PROPOF-I
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IND_TIPO_CONTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOVA_NUM_CERTIFICADO}'";

            return query;
        }
        public string PROPOFID_IND_TIPO_CONTA { get; set; }
        public string PROPOF_I { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_IND_TIPO_CONTA = result[i++].Value?.ToString();
            dta.PROPOF_I = string.IsNullOrWhiteSpace(dta.PROPOFID_IND_TIPO_CONTA) ? "-1" : "0";
            return dta;
        }

    }
}