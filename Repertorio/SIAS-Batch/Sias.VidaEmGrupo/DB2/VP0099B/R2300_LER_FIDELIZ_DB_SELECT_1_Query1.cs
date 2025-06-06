using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2300_LER_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R2300_LER_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA
            INTO :PROPOFID-COD-PESSOA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_COD_PESSOA { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R2300_LER_FIDELIZ_DB_SELECT_1_Query1 Execute(R2300_LER_FIDELIZ_DB_SELECT_1_Query1 r2300_LER_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r2300_LER_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2300_LER_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2300_LER_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}