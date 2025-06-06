using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1613B
{
    public class R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE ,
            NUM_APOLICE ,
            COD_MODALIDADE ,
            ORGAO_EMISSOR ,
            RAMO_EMISSOR ,
            COD_PRODUTO ,
            NUM_BILHETE ,
            TIPO_APOLICE
            INTO :APOLICES-COD-CLIENTE ,
            :APOLICES-NUM-APOLICE ,
            :APOLICES-COD-MODALIDADE ,
            :APOLICES-ORGAO-EMISSOR ,
            :APOLICES-RAMO-EMISSOR ,
            :APOLICES-COD-PRODUTO ,
            :APOLICES-NUM-BILHETE ,
            :APOLICES-TIPO-APOLICE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE 
							,
											NUM_APOLICE 
							,
											COD_MODALIDADE 
							,
											ORGAO_EMISSOR 
							,
											RAMO_EMISSOR 
							,
											COD_PRODUTO 
							,
											NUM_BILHETE 
							,
											TIPO_APOLICE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.SUBGVGAP_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_COD_CLIENTE { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string APOLICES_NUM_BILHETE { get; set; }
        public string APOLICES_TIPO_APOLICE { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1 r3205_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r3205_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3205_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_CLIENTE = result[i++].Value?.ToString();
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            dta.APOLICES_NUM_BILHETE = result[i++].Value?.ToString();
            dta.APOLICES_TIPO_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}