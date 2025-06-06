using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0816B
{
    public class R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE CODUSU = :V0RELA-COD-USU
            AND DATA_SOLICITACAO = :V0RELA-DATA-SOL
            AND IDSISTEM = :V0RELA-IDSISTEM
            AND CODRELAT = :V0RELA-CODRELAT
            AND CONGENER = :V0RELA-CONGENER
            AND COD_EMPRESA = :V0RELA-COD-EMPR
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE CODUSU = '{this.V0RELA_COD_USU}'
				AND DATA_SOLICITACAO = '{this.V0RELA_DATA_SOL}'
				AND IDSISTEM = '{this.V0RELA_IDSISTEM}'
				AND CODRELAT = '{this.V0RELA_CODRELAT}'
				AND CONGENER = '{this.V0RELA_CONGENER}'
				AND COD_EMPRESA = '{this.V0RELA_COD_EMPR}'";

            return query;
        }
        public string V0RELA_COD_USU { get; set; }
        public string V0RELA_DATA_SOL { get; set; }
        public string V0RELA_IDSISTEM { get; set; }
        public string V0RELA_CODRELAT { get; set; }
        public string V0RELA_CONGENER { get; set; }
        public string V0RELA_COD_EMPR { get; set; }

        public static void Execute(R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 r2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}