using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0005S
{
    public class P0111_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0111_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_MOTIVO_SIVPF
            INTO :PFMOTPRO-SIT-MOTIVO-SIVPF
            FROM SEGUROS.PF_MOTIVO_PROPOSTA
            WHERE SIT_MOTIVO_SIVPF = :PFMOTPRO-SIT-MOTIVO-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_MOTIVO_SIVPF
											FROM SEGUROS.PF_MOTIVO_PROPOSTA
											WHERE SIT_MOTIVO_SIVPF = '{this.PFMOTPRO_SIT_MOTIVO_SIVPF}'
											WITH UR";

            return query;
        }
        public string PFMOTPRO_SIT_MOTIVO_SIVPF { get; set; }

        public static P0111_05_INICIO_DB_SELECT_1_Query1 Execute(P0111_05_INICIO_DB_SELECT_1_Query1 p0111_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0111_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0111_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0111_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PFMOTPRO_SIT_MOTIVO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}