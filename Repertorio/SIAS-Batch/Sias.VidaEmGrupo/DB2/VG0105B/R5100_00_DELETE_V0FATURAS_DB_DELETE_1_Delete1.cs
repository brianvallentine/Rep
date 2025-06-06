using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0105B
{
    public class R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1 : QueryBasis<R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0FATURAS
            WHERE NUM_APOLICE = :W1SOLF-NUM-APOL
            AND COD_SUBGRUPO = :W1SOLF-COD-SUBG
            AND NUM_FATURA = :W1SOLF-NUM-FAT
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0FATURAS
				WHERE NUM_APOLICE = '{this.W1SOLF_NUM_APOL}'
				AND COD_SUBGRUPO = '{this.W1SOLF_COD_SUBG}'
				AND NUM_FATURA = '{this.W1SOLF_NUM_FAT}'";

            return query;
        }
        public string W1SOLF_NUM_APOL { get; set; }
        public string W1SOLF_COD_SUBG { get; set; }
        public string W1SOLF_NUM_FAT { get; set; }

        public static void Execute(R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1 r5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1)
        {
            var ths = r5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5100_00_DELETE_V0FATURAS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}