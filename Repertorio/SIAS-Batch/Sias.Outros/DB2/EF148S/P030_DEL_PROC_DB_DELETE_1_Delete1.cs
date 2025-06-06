using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.EF148S
{
    public class P030_DEL_PROC_DB_DELETE_1_Delete1 : QueryBasis<P030_DEL_PROC_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            DELETE FROM SEGUROS.EF_PROD_ACESSORIO
            WHERE NUM_CONTRATO_APOL = :EF148-NUM-CONTRATO-APOL
            AND COD_PRODUTO = :EF148-COD-PRODUTO
            AND COD_COBERTURA = :EF148-COD-COBERTURA
            AND DTH_INI_VIGENCIA = :EF148-DTH-INI-VIGENCIA
            END-EXEC
            */
            #endregion
            var query = @$"
				DELETE FROM SEGUROS.EF_PROD_ACESSORIO
				WHERE NUM_CONTRATO_APOL = '{this.EF148_NUM_CONTRATO_APOL}'
				AND COD_PRODUTO = '{this.EF148_COD_PRODUTO}'
				AND COD_COBERTURA = '{this.EF148_COD_COBERTURA}'
				AND DTH_INI_VIGENCIA = '{this.EF148_DTH_INI_VIGENCIA}'";

            return query;
        }
        public string EF148_NUM_CONTRATO_APOL { get; set; }
        public string EF148_COD_PRODUTO { get; set; }
        public string EF148_COD_COBERTURA { get; set; }
        public string EF148_DTH_INI_VIGENCIA { get; set; }

        public static void Execute(P030_DEL_PROC_DB_DELETE_1_Delete1 p030_DEL_PROC_DB_DELETE_1_Delete1)
        {
            var ths = p030_DEL_PROC_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P030_DEL_PROC_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}