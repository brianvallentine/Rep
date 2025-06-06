using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0642B
{
    public class R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 : QueryBasis<R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VAL_TARIFA
            INTO
            :DCLTARIFA-BALCAO-CEF.VAL-TARIFA
            FROM SEGUROS.TARIFA_BALCAO_CEF
            WHERE COD_EMPRESA = 0
            AND NUM_MATRICULA = 9999999
            AND TIPO_FUNCIONARIO = '5'
            AND (NUM_CERTIFICADO =
            :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO
            OR NUM_CERTIFICADO = :WHOST-NUM-TERMO)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VAL_TARIFA
											FROM SEGUROS.TARIFA_BALCAO_CEF
											WHERE COD_EMPRESA = 0
											AND NUM_MATRICULA = 9999999
											AND TIPO_FUNCIONARIO = '5'
											AND (NUM_CERTIFICADO =
											'{this.NUM_CERTIFICADO}'
											OR NUM_CERTIFICADO = '{this.WHOST_NUM_TERMO}')
											WITH UR";

            return query;
        }
        public string VAL_TARIFA { get; set; }
        public string NUM_CERTIFICADO { get; set; }
        public string WHOST_NUM_TERMO { get; set; }

        public static R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 Execute(R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1)
        {
            var ths = r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1();
            var i = 0;
            dta.VAL_TARIFA = result[i++].Value?.ToString();
            return dta;
        }

    }
}