using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1 : QueryBasis<R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PF_CBO VALUES
            (:PF062-NUM-PROPOSTA-SIVPF,
            :PF062-COD-CBO ,
            :PF062-DES-CBO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PF_CBO VALUES ({FieldThreatment(this.PF062_NUM_PROPOSTA_SIVPF)}, {FieldThreatment(this.PF062_COD_CBO)} , {FieldThreatment(this.PF062_DES_CBO)})";

            return query;
        }
        public string PF062_NUM_PROPOSTA_SIVPF { get; set; }
        public string PF062_COD_CBO { get; set; }
        public string PF062_DES_CBO { get; set; }

        public static void Execute(R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1 r0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1)
        {
            var ths = r0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0495_00_INCLUIR_PF_CBO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}