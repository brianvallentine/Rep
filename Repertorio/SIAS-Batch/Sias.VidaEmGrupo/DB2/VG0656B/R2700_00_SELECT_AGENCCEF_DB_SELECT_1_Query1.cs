using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0656B
{
    public class R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 : QueryBasis<R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NOME_AGENCIA,
            A.COD_ESCNEG,
            B.REGIAO_ESCNEG
            INTO :AGENCCEF-NOME-AGENCIA,
            :AGENCCEF-COD-ESCNEG,
            :ESCRINEG-REGIAO-ESCNEG
            FROM SEGUROS.AGENCIAS_CEF A,
            SEGUROS.ESCRITORIO_NEGOCIO B
            WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA
            AND B.COD_ESCNEG = A.COD_ESCNEG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NOME_AGENCIA
							,
											A.COD_ESCNEG
							,
											B.REGIAO_ESCNEG
											FROM SEGUROS.AGENCIAS_CEF A
							,
											SEGUROS.ESCRITORIO_NEGOCIO B
											WHERE A.COD_AGENCIA = '{this.AGENCCEF_COD_AGENCIA}'
											AND B.COD_ESCNEG = A.COD_ESCNEG";

            return query;
        }
        public string AGENCCEF_NOME_AGENCIA { get; set; }
        public string AGENCCEF_COD_ESCNEG { get; set; }
        public string ESCRINEG_REGIAO_ESCNEG { get; set; }
        public string AGENCCEF_COD_AGENCIA { get; set; }

        public static R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 Execute(R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 r2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1)
        {
            var ths = r2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.AGENCCEF_NOME_AGENCIA = result[i++].Value?.ToString();
            dta.AGENCCEF_COD_ESCNEG = result[i++].Value?.ToString();
            dta.ESCRINEG_REGIAO_ESCNEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}