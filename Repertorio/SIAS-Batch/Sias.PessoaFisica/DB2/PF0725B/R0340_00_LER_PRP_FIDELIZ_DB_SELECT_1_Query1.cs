using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0725B
{
    public class R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF ,
            NUM_IDENTIFICACAO
            INTO :PROPOFID-NUM-PROPOSTA-SIVPF ,
            :PROPOFID-NUM-IDENTIFICACAO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :PROPOFID-NUM-SICOB
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF 
							,
											NUM_IDENTIFICACAO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.PROPOFID_NUM_SICOB}'
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }

        public static R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 r0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0340_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}