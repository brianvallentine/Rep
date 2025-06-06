using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0710S
{
    public class M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 : QueryBasis<M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT TAXA_VG
            INTO :TAXA-VG
            FROM SEGUROS.V1FAIXAETA
            WHERE NUM_APOLICE = :NUM-APOLICE
            AND COD_SUBGRUPO = :COD-SUBGRUPO
            AND IDADE_INICIAL >= :IDADE
            AND IDADE_FINAL <= :IDADE
            AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT TAXA_VG
											FROM SEGUROS.V1FAIXAETA
											WHERE NUM_APOLICE = '{this.NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.COD_SUBGRUPO}'
											AND IDADE_INICIAL >= '{this.IDADE}'
											AND IDADE_FINAL <= '{this.IDADE}'
											AND DATA_TERVIGENCIA IN ( '1999-12-31' 
							, '9999-12-31' )";

            return query;
        }
        public string TAXA_VG { get; set; }
        public string COD_SUBGRUPO { get; set; }
        public string NUM_APOLICE { get; set; }
        public string IDADE { get; set; }

        public static M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 Execute(M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1)
        {
            var ths = m_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0020_ACESSA_FAIXA_ETARIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.TAXA_VG = result[i++].Value?.ToString();
            return dta;
        }

    }
}