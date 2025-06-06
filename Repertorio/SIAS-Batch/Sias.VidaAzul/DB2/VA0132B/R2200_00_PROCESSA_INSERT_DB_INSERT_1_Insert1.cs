using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0132B
{
    public class R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1 : QueryBasis<R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VA_CAMPANHA_CARENCIA
            ( NUM_CPF_CNPJ
            ,COD_USUARIO
            ,DTH_INCLUSAO
            )
            VALUES
            (
            :VA111-NUM-CPF-CNPJ
            ,:VA111-COD-USUARIO
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VA_CAMPANHA_CARENCIA ( NUM_CPF_CNPJ ,COD_USUARIO ,DTH_INCLUSAO ) VALUES ( {FieldThreatment(this.VA111_NUM_CPF_CNPJ)} ,{FieldThreatment(this.VA111_COD_USUARIO)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string VA111_NUM_CPF_CNPJ { get; set; }
        public string VA111_COD_USUARIO { get; set; }

        public static void Execute(R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1 r2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = r2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_PROCESSA_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}