using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0715B
{
    public class R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1 : QueryBasis<R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_MOTIVO_SIVPF
            INTO :PF037-SIT-MOTIVO-SIVPF
            FROM SEGUROS.PF_ERRO_DEVOLUCAO
            WHERE COD_DEVOLUCAO = :PF037-COD-DEVOLUCAO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_MOTIVO_SIVPF
											FROM SEGUROS.PF_ERRO_DEVOLUCAO
											WHERE COD_DEVOLUCAO = '{this.PF037_COD_DEVOLUCAO}'
											WITH UR";

            return query;
        }
        public string PF037_SIT_MOTIVO_SIVPF { get; set; }
        public string PF037_COD_DEVOLUCAO { get; set; }

        public static R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1 Execute(R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1 r0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1();
            var i = 0;
            dta.PF037_SIT_MOTIVO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}