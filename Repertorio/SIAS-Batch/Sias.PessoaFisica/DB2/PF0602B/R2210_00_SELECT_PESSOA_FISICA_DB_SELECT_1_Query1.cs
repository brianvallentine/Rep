using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 : QueryBasis<R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CPF,
            DATA_NASCIMENTO,
            SEXO,
            COD_CBO,
            ESTADO_CIVIL,
            ORGAO_EXPEDIDOR,
            NUM_IDENTIDADE,
            DATA_EXPEDICAO,
            UF_EXPEDIDORA
            INTO :DCLPESSOA-FISICA.CPF,
            :DCLPESSOA-FISICA.DATA-NASCIMENTO,
            :DCLPESSOA-FISICA.SEXO,
            :DCLPESSOA-FISICA.COD-CBO,
            :DCLPESSOA-FISICA.ESTADO-CIVIL,
            :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR,
            :DCLPESSOA-FISICA.NUM-IDENTIDADE,
            :DCLPESSOA-FISICA.DATA-EXPEDICAO
            :VIND-DATA-EXPEDICAO,
            :DCLPESSOA-FISICA.UF-EXPEDIDORA
            :VIND-UF-EXPEDIDORA
            FROM SEGUROS.PESSOA_FISICA
            WHERE COD_PESSOA = :DCLPROPOSTA-FIDELIZ.COD-PESSOA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CPF
							,
											DATA_NASCIMENTO
							,
											SEXO
							,
											COD_CBO
							,
											ESTADO_CIVIL
							,
											ORGAO_EXPEDIDOR
							,
											NUM_IDENTIDADE
							,
											DATA_EXPEDICAO
							,
											UF_EXPEDIDORA
											FROM SEGUROS.PESSOA_FISICA
											WHERE COD_PESSOA = '{this.COD_PESSOA}'
											WITH UR";

            return query;
        }
        public string CPF { get; set; }
        public string DATA_NASCIMENTO { get; set; }
        public string SEXO { get; set; }
        public string COD_CBO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string ORGAO_EXPEDIDOR { get; set; }
        public string NUM_IDENTIDADE { get; set; }
        public string DATA_EXPEDICAO { get; set; }
        public string VIND_DATA_EXPEDICAO { get; set; }
        public string UF_EXPEDIDORA { get; set; }
        public string VIND_UF_EXPEDIDORA { get; set; }
        public string COD_PESSOA { get; set; }

        public static R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 Execute(R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1)
        {
            var ths = r2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2210_00_SELECT_PESSOA_FISICA_DB_SELECT_1_Query1();
            var i = 0;
            dta.CPF = result[i++].Value?.ToString();
            dta.DATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.SEXO = result[i++].Value?.ToString();
            dta.COD_CBO = result[i++].Value?.ToString();
            dta.ESTADO_CIVIL = result[i++].Value?.ToString();
            dta.ORGAO_EXPEDIDOR = result[i++].Value?.ToString();
            dta.NUM_IDENTIDADE = result[i++].Value?.ToString();
            dta.DATA_EXPEDICAO = result[i++].Value?.ToString();
            dta.VIND_DATA_EXPEDICAO = string.IsNullOrWhiteSpace(dta.DATA_EXPEDICAO) ? "-1" : "0";
            dta.UF_EXPEDIDORA = result[i++].Value?.ToString();
            dta.VIND_UF_EXPEDIDORA = string.IsNullOrWhiteSpace(dta.UF_EXPEDIDORA) ? "-1" : "0";
            return dta;
        }

    }
}