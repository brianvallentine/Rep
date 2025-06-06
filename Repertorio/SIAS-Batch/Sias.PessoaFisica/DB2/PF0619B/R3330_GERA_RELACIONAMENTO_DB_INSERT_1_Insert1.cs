using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0619B
{
    public class R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 : QueryBasis<R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES
            (:DCLR-PESSOA-TIPORELAC.COD-PESSOA,
            :DCLR-PESSOA-TIPORELAC.COD-RELAC)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES ({FieldThreatment(this.COD_PESSOA)}, {FieldThreatment(this.COD_RELAC)})";

            return query;
        }
        public string COD_PESSOA { get; set; }
        public string COD_RELAC { get; set; }

        public static void Execute(R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1)
        {
            var ths = r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}