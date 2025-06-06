using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0004B
{
    public class R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 : QueryBasis<R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL DELETE
            FROM SEGUROS.V0RELATORIOS
            WHERE CODRELAT = 'AC0004B1'
            AND DATA_SOLICITACAO = :V0SIST-DTMOVABE-AC
            AND PERI_INICIAL = :V0RELA-PERI-INICIAL
            AND PERI_FINAL = :V0RELA-PERI-FINAL
            AND CONGENER = :V0RELA-CONGENER
            AND COD_EMPRESA = :V0RELA-COD-EMPR
            END-EXEC.
            */
            #endregion
            var query = @$"
				DELETE
				FROM SEGUROS.V0RELATORIOS
				WHERE CODRELAT = 'AC0004B1'
				AND DATA_SOLICITACAO = '{this.V0SIST_DTMOVABE_AC}'
				AND PERI_INICIAL = '{this.V0RELA_PERI_INICIAL}'
				AND PERI_FINAL = '{this.V0RELA_PERI_FINAL}'
				AND CONGENER = '{this.V0RELA_CONGENER}'
				AND COD_EMPRESA = '{this.V0RELA_COD_EMPR}'";

            return query;
        }
        public string V0SIST_DTMOVABE_AC { get; set; }
        public string V0RELA_PERI_INICIAL { get; set; }
        public string V0RELA_PERI_FINAL { get; set; }
        public string V0RELA_CONGENER { get; set; }
        public string V0RELA_COD_EMPR { get; set; }

        public static void Execute(R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 r3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1)
        {
            var ths = r3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3000_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}