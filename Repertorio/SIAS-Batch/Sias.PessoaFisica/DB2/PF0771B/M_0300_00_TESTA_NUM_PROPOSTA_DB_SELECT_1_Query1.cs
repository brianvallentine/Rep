using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0771B
{
    public class M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIGEM_PROPOSTA
            INTO :PROPOFID-ORIGEM-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORIGEM_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_ORIGEM_PROPOSTA { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1 Execute(M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1 m_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = m_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}