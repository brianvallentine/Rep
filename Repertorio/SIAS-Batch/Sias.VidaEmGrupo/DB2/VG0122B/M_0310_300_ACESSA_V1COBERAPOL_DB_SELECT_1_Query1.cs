using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0122B
{
    public class M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1 : QueryBasis<M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT IMP_SEGURADA_IX ,
            PRM_TARIFARIO_IX ,
            FATOR_MULTIPLICA
            INTO :COBERAPOL-SEGUR-IX,
            :COBERAPOL-PREM-IX,
            :COBERAPOL-FATOR-MULTIPLICA
            FROM SEGUROS.V1COBERAPOL
            WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL
            AND NRENDOS = 0
            AND NUM_ITEM = :SEGURAVG-NUM-ITEM
            AND OCORHIST = :SEGURAVG-OCORR-HI
            AND RAMOFR = :COBERAPOL-RAMO
            AND MODALIFR = 0
            AND COD_COBERTURA = :COBERAPOL-COBERT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEGURADA_IX 
							,
											PRM_TARIFARIO_IX 
							,
											FATOR_MULTIPLICA
											FROM SEGUROS.V1COBERAPOL
											WHERE NUM_APOLICE = '{this.SEGURAVG_NUM_APOL}'
											AND NRENDOS = 0
											AND NUM_ITEM = '{this.SEGURAVG_NUM_ITEM}'
											AND OCORHIST = '{this.SEGURAVG_OCORR_HI}'
											AND RAMOFR = '{this.COBERAPOL_RAMO}'
											AND MODALIFR = 0
											AND COD_COBERTURA = '{this.COBERAPOL_COBERT}'";

            return query;
        }
        public string COBERAPOL_SEGUR_IX { get; set; }
        public string COBERAPOL_PREM_IX { get; set; }
        public string COBERAPOL_FATOR_MULTIPLICA { get; set; }
        public string SEGURAVG_NUM_APOL { get; set; }
        public string SEGURAVG_NUM_ITEM { get; set; }
        public string SEGURAVG_OCORR_HI { get; set; }
        public string COBERAPOL_COBERT { get; set; }
        public string COBERAPOL_RAMO { get; set; }

        public static M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1 Execute(M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1 m_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1)
        {
            var ths = m_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBERAPOL_SEGUR_IX = result[i++].Value?.ToString();
            dta.COBERAPOL_PREM_IX = result[i++].Value?.ToString();
            dta.COBERAPOL_FATOR_MULTIPLICA = result[i++].Value?.ToString();
            return dta;
        }

    }
}