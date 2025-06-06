using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0702S
{
    public class M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1 : QueryBasis<M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT TAXA_VG
            INTO :TAXA-VG
            FROM SEGUROS.V1FAIXASAL
            WHERE NUM_APOLICE = :NUM-APOLICE
            AND COD_SUBGRUPO = :COD-SUBGRUPO
            AND SALARIO_INICIAL >= :SALARIO
            AND SALARIO_FINAL <= :SALARIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXA_VG
											FROM SEGUROS.V1FAIXASAL
											WHERE NUM_APOLICE = '{this.NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.COD_SUBGRUPO}'
											AND SALARIO_INICIAL >= '{this.SALARIO}'
											AND SALARIO_FINAL <= '{this.SALARIO}'";

            return query;
        }
        public string TAXA_VG { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string NUM_APOLICE { get; set; }
        public string SALARIO { get; set; }

        public static M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1 Execute(M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1 m_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1)
        {
            var ths = m_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0030_ACESSA_FAIXA_SALARIAL_DB_SELECT_1_Query1();
            var i = 0;
            dta.TAXA_VG = result[i++].Value?.ToString();
            return dta;
        }

    }
}