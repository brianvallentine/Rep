using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1 : QueryBasis<R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_AGENCIA,
            COD_SUREG,
            COD_ESCNEG,
            SITUACAO
            INTO :V1AGENC-COD-AGENCIA,
            :V1AGENC-COD-SUREG,
            :V1AGENC-COD-ESCNEG,
            :V1AGENC-SITUACAO
            FROM SEGUROS.V1AGENCIACEF
            WHERE COD_AGENCIA = :V0TERMO-COD-AGE-OP
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_AGENCIA
							,
											COD_SUREG
							,
											COD_ESCNEG
							,
											SITUACAO
											FROM SEGUROS.V1AGENCIACEF
											WHERE COD_AGENCIA = '{this.V0TERMO_COD_AGE_OP}'
											WITH UR";

            return query;
        }
        public string V1AGENC_COD_AGENCIA { get; set; }
        public string V1AGENC_COD_SUREG { get; set; }
        public string V1AGENC_COD_ESCNEG { get; set; }
        public string V1AGENC_SITUACAO { get; set; }
        public string V0TERMO_COD_AGE_OP { get; set; }

        public static R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1 Execute(R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1 r0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1)
        {
            var ths = r0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0280_00_LER_V1AGENCIACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1AGENC_COD_AGENCIA = result[i++].Value?.ToString();
            dta.V1AGENC_COD_SUREG = result[i++].Value?.ToString();
            dta.V1AGENC_COD_ESCNEG = result[i++].Value?.ToString();
            dta.V1AGENC_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}