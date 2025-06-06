using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0601B
{
    public class R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 : QueryBasis<R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT
            INTO SEGUROS.GE_DOC_CLIENTE
            (COD_CLIENTE ,
            COD_IDENTIFICACAO ,
            NOM_ORGAO_EXP ,
            DTH_EXPEDICAO ,
            COD_UF)
            VALUES (:GEDOCCLI-COD-CLIENTE ,
            ' ' ,
            ' ' ,
            '9999-12-31' ,
            ' ' )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES ({FieldThreatment(this.GEDOCCLI_COD_CLIENTE)} , ' ' , ' ' , '9999-12-31' , ' ' )";

            return query;
        }
        public string GEDOCCLI_COD_CLIENTE { get; set; }

        public static void Execute(R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1)
        {
            var ths = r2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2315_00_INSERT_GE_DOC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}