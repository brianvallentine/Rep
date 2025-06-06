using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0605B
{
    public class R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1 : QueryBasis<R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :NUM-APOL-ANT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.NUM_APOL_ANT}'";

            return query;
        }
        public string NUM_PROPOSTA_SIVPF { get; set; }
        public string NUM_APOL_ANT { get; set; }

        public static R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1 Execute(R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1 r0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1)
        {
            var ths = r0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}