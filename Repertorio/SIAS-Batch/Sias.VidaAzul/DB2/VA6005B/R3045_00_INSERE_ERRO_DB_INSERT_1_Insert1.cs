using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA6005B
{
    public class R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1 : QueryBasis<R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0BILHETE_ERROS
            VALUES (:V0BILH-NUMBIL,
            :V0BILER-COD-ERRO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0BILHETE_ERROS VALUES ({FieldThreatment(this.V0BILH_NUMBIL)}, {FieldThreatment(this.V0BILER_COD_ERRO)})";

            return query;
        }
        public string V0BILH_NUMBIL { get; set; }
        public string V0BILER_COD_ERRO { get; set; }

        public static void Execute(R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1 r3045_00_INSERE_ERRO_DB_INSERT_1_Insert1)
        {
            var ths = r3045_00_INSERE_ERRO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3045_00_INSERE_ERRO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}