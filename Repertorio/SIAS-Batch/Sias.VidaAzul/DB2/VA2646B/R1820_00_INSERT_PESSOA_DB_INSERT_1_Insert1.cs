using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1 : QueryBasis<R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA VALUES
            (:PESSOA-COD-PESSOA,
            :CLIENTES-NOME-RAZAO,
            CURRENT TIMESTAMP,
            :PESSOA-COD-USUARIO,
            :CLIENTES-TIPO-PESSOA,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA VALUES ({FieldThreatment(this.PESSOA_COD_PESSOA)}, {FieldThreatment(this.CLIENTES_NOME_RAZAO)}, CURRENT TIMESTAMP, {FieldThreatment(this.PESSOA_COD_USUARIO)}, {FieldThreatment(this.CLIENTES_TIPO_PESSOA)}, NULL)";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string CLIENTES_NOME_RAZAO { get; set; }
        public string PESSOA_COD_USUARIO { get; set; }
        public string CLIENTES_TIPO_PESSOA { get; set; }

        public static void Execute(R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1 r1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1)
        {
            var ths = r1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1820_00_INSERT_PESSOA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}