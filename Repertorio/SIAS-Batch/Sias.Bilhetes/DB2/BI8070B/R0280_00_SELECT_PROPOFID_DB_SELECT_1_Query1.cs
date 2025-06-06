using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            ,ORIGEM_PROPOSTA
            INTO :PROPOFID-NUM-PROPOSTA-SIVPF
            ,:PROPOFID-ORIGEM-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :BILHETE-NUM-BILHETE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											,ORIGEM_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.BILHETE_NUM_BILHETE}'
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string BILHETE_NUM_BILHETE { get; set; }

        public static R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}