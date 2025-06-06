using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0010B
{
    public class M_1000_COBERTURAS_DB_SELECT_8_Query1 : QueryBasis<M_1000_COBERTURAS_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEGURADA_IX,
            FATOR_MULTIPLICA
            INTO :CIMP-SEGURADA-DIT,
            :CFATOR-MULTIPLICA
            FROM SEGUROS.V0COBERAPOL
            WHERE NUM_APOLICE = :V1SEGV-NUM-APOLICE
            AND NRENDOS = 0
            AND NUM_ITEM = :V1SEGV-ITEM
            AND OCORHIST = :V1SEGV-OCORHIST
            AND RAMOFR = 81
            AND MODALIFR >= 0
            AND COD_COBERTURA = 05
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX
							,
											FATOR_MULTIPLICA
											FROM SEGUROS.V0COBERAPOL
											WHERE NUM_APOLICE = '{this.V1SEGV_NUM_APOLICE}'
											AND NRENDOS = 0
											AND NUM_ITEM = '{this.V1SEGV_ITEM}'
											AND OCORHIST = '{this.V1SEGV_OCORHIST}'
											AND RAMOFR = 81
											AND MODALIFR >= 0
											AND COD_COBERTURA = 05";

            return query;
        }
        public string CIMP_SEGURADA_DIT { get; set; }
        public string CFATOR_MULTIPLICA { get; set; }
        public string V1SEGV_NUM_APOLICE { get; set; }
        public string V1SEGV_OCORHIST { get; set; }
        public string V1SEGV_ITEM { get; set; }

        public static M_1000_COBERTURAS_DB_SELECT_8_Query1 Execute(M_1000_COBERTURAS_DB_SELECT_8_Query1 m_1000_COBERTURAS_DB_SELECT_8_Query1)
        {
            var ths = m_1000_COBERTURAS_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1000_COBERTURAS_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1000_COBERTURAS_DB_SELECT_8_Query1();
            var i = 0;
            dta.CIMP_SEGURADA_DIT = result[i++].Value?.ToString();
            dta.CFATOR_MULTIPLICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}