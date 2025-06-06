using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0099B
{
    public class R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1 : QueryBasis<R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO,
            SEXO,
            ESTADO_CIVIL,
            VALUE(NUM_IDENTIDADE, ' ' ),
            VALUE(COD_CBO, 0)
            INTO :PESSOFIS-DATA-NASCIMENTO,
            :PESSOFIS-SEXO,
            :PESSOFIS-ESTADO-CIVIL,
            :PESSOFIS-NUM-IDENTIDADE,
            :PESSOFIS-COD-CBO
            FROM SEGUROS.PESSOA_FISICA
            WHERE COD_PESSOA = :PESSOFIS-COD-PESSOA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO
							,
											SEXO
							,
											ESTADO_CIVIL
							,
											VALUE(NUM_IDENTIDADE
							, ' ' )
							,
											VALUE(COD_CBO
							, 0)
											FROM SEGUROS.PESSOA_FISICA
											WHERE COD_PESSOA = '{this.PESSOFIS_COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string PESSOFIS_DATA_NASCIMENTO { get; set; }
        public string PESSOFIS_SEXO { get; set; }
        public string PESSOFIS_ESTADO_CIVIL { get; set; }
        public string PESSOFIS_NUM_IDENTIDADE { get; set; }
        public string PESSOFIS_COD_CBO { get; set; }
        public string PESSOFIS_COD_PESSOA { get; set; }

        public static R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1 Execute(R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1 r2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1)
        {
            var ths = r2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_LER_PESSOA_FISICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOFIS_DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.PESSOFIS_SEXO = result[i++].Value?.ToString();
            dta.PESSOFIS_ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.PESSOFIS_NUM_IDENTIDADE = result[i++].Value?.ToString();
            dta.PESSOFIS_COD_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}