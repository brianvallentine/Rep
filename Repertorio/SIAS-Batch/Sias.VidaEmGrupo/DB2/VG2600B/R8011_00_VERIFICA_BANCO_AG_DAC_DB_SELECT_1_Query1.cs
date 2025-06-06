using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1 : QueryBasis<R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_AGENCIA
            INTO :AGENCIAS-NOME-AGENCIA
            FROM SEGUROS.AGENCIAS
            WHERE COD_BANCO = :AGENCIAS-COD-BANCO
            AND COD_AGENCIA = :AGENCIAS-COD-AGENCIA
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_AGENCIA
											FROM SEGUROS.AGENCIAS
											WHERE COD_BANCO = '{this.AGENCIAS_COD_BANCO}'
											AND COD_AGENCIA = '{this.AGENCIAS_COD_AGENCIA}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string AGENCIAS_NOME_AGENCIA { get; set; }
        public string AGENCIAS_COD_AGENCIA { get; set; }
        public string AGENCIAS_COD_BANCO { get; set; }

        public static R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1 Execute(R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1 r8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1)
        {
            var ths = r8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8011_00_VERIFICA_BANCO_AG_DAC_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCIAS_NOME_AGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}