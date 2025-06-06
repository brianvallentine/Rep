using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8024B
{
    public class R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1 : QueryBasis<R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.GE_DES_RETORNO_CIELO
            (
            COD_MOVIMENTO
            , COD_RETORNO
            , DES_COD_RETORNO
            )
            VALUES
            (
            :GE409-COD-MOVIMENTO
            , :GE409-COD-RETORNO
            , :GE409-DES-COD-RETORNO
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_DES_RETORNO_CIELO ( COD_MOVIMENTO , COD_RETORNO , DES_COD_RETORNO ) VALUES ( {FieldThreatment(this.GE409_COD_MOVIMENTO)} , {FieldThreatment(this.GE409_COD_RETORNO)} , {FieldThreatment(this.GE409_DES_COD_RETORNO)} )";

            return query;
        }
        public string GE409_COD_MOVIMENTO { get; set; }
        public string GE409_COD_RETORNO { get; set; }
        public string GE409_DES_COD_RETORNO { get; set; }

        public static void Execute(R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1 r0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1)
        {
            var ths = r0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0580_00_INSERIR_COD_RET_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}