using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE CODUSU = :V1RELA-COD-USU
            AND DATA_SOLICITACAO = :V1RELA-DATA-SOL
            AND IDSISTEM = :V1RELA-IDSISTEM
            AND CODRELAT = :V1RELA-CODRELAT
            AND CONGENER = :V1RELA-CONGENER
            AND COD_EMPRESA = :V1RELA-COD-EMPR
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE CODUSU = '{this.V1RELA_COD_USU}'
				AND DATA_SOLICITACAO = '{this.V1RELA_DATA_SOL}'
				AND IDSISTEM = '{this.V1RELA_IDSISTEM}'
				AND CODRELAT = '{this.V1RELA_CODRELAT}'
				AND CONGENER = '{this.V1RELA_CONGENER}'
				AND COD_EMPRESA = '{this.V1RELA_COD_EMPR}'";

            return query;
        }
        public string V1RELA_COD_USU { get; set; }
        public string V1RELA_DATA_SOL { get; set; }
        public string V1RELA_IDSISTEM { get; set; }
        public string V1RELA_CODRELAT { get; set; }
        public string V1RELA_CONGENER { get; set; }
        public string V1RELA_COD_EMPR { get; set; }

        public static void Execute(R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 r3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3500_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}