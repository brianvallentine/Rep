using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0007B
{
    public class R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE ,
            NRENDOS ,
            RAMO ,
            CODPRODU ,
            QTPARCEL ,
            COD_MOEDA_PRM ,
            DTINIVIG ,
            CORRECAO ,
            TIPO_ENDOSSO ,
            VALUE(COD_EMPRESA,+0)
            INTO :V0ENDO-NUM-APOL ,
            :V0ENDO-NRENDOS ,
            :V0ENDO-RAMO ,
            :V0ENDO-CODPRODU ,
            :V0ENDO-QTPARCEL ,
            :V0ENDO-MOEDA-PRM ,
            :V0ENDO-DTINIVIG ,
            :V0ENDO-CORRECAO ,
            :V0ENDO-TIPO-ENDO ,
            :V0ENDO-COD-EMPR
            FROM SEGUROS.V0ENDOSSO
            WHERE NUM_APOLICE = :V0HISP-NUM-APOL
            AND NRENDOS = :V0HISP-NRENDOS
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											NRENDOS 
							,
											RAMO 
							,
											CODPRODU 
							,
											QTPARCEL 
							,
											COD_MOEDA_PRM 
							,
											DTINIVIG 
							,
											CORRECAO 
							,
											TIPO_ENDOSSO 
							,
											VALUE(COD_EMPRESA
							,+0)
											FROM SEGUROS.V0ENDOSSO
											WHERE NUM_APOLICE = '{this.V0HISP_NUM_APOL}'
											AND NRENDOS = '{this.V0HISP_NRENDOS}'";

            return query;
        }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0ENDO_RAMO { get; set; }
        public string V0ENDO_CODPRODU { get; set; }
        public string V0ENDO_QTPARCEL { get; set; }
        public string V0ENDO_MOEDA_PRM { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V0ENDO_CORRECAO { get; set; }
        public string V0ENDO_TIPO_ENDO { get; set; }
        public string V0ENDO_COD_EMPR { get; set; }
        public string V0HISP_NUM_APOL { get; set; }
        public string V0HISP_NRENDOS { get; set; }

        public static R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 r1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_NUM_APOL = result[i++].Value?.ToString();
            dta.V0ENDO_NRENDOS = result[i++].Value?.ToString();
            dta.V0ENDO_RAMO = result[i++].Value?.ToString();
            dta.V0ENDO_CODPRODU = result[i++].Value?.ToString();
            dta.V0ENDO_QTPARCEL = result[i++].Value?.ToString();
            dta.V0ENDO_MOEDA_PRM = result[i++].Value?.ToString();
            dta.V0ENDO_DTINIVIG = result[i++].Value?.ToString();
            dta.V0ENDO_CORRECAO = result[i++].Value?.ToString();
            dta.V0ENDO_TIPO_ENDO = result[i++].Value?.ToString();
            dta.V0ENDO_COD_EMPR = result[i++].Value?.ToString();
            return dta;
        }

    }
}