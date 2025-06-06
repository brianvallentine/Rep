using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0120B
{
    public class M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1 : QueryBasis<M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT NUM_APOLICE ,
            COD_SUBGRUPO ,
            COD_CLIENTE ,
            NUM_CERTIFICADO ,
            DAC_CERTIFICADO ,
            TIPO_SEGURADO ,
            NUM_ITEM ,
            OCORR_HISTORICO ,
            ESTADO_CIVIL ,
            IDE_SEXO ,
            NUM_MATRICULA ,
            DATA_INIVIGENCIA ,
            SIT_REGISTRO ,
            DATA_NASCIMENTO
            INTO :SEGURAVG-NUM-APOL ,
            :SEGURAVG-COD-SUBG ,
            :SEGURAVG-COD-CLI ,
            :SEGURAVG-NUM-CERT ,
            :SEGURAVG-DAC-CERT ,
            :SEGURAVG-TIPO-SEG ,
            :SEGURAVG-NUM-ITEM ,
            :SEGURAVG-OCORR-HI ,
            :SEGURAVG-EST-CIVIL ,
            :SEGURAVG-IDE-SEXO ,
            :SEGURAVG-MATRICULA ,
            :SEGURAVG-DT-INIVI ,
            :SEGURAVG-SIT-REG ,
            :SEGURAVG-DT-NASCI
            FROM SEGUROS.V1SEGURAVG
            WHERE NUM_CERTIFICADO = :AUX-CERTIFICADO
            AND TIPO_SEGURADO = '2'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE 
							,
											COD_SUBGRUPO 
							,
											COD_CLIENTE 
							,
											NUM_CERTIFICADO 
							,
											DAC_CERTIFICADO 
							,
											TIPO_SEGURADO 
							,
											NUM_ITEM 
							,
											OCORR_HISTORICO 
							,
											ESTADO_CIVIL 
							,
											IDE_SEXO 
							,
											NUM_MATRICULA 
							,
											DATA_INIVIGENCIA 
							,
											SIT_REGISTRO 
							,
											DATA_NASCIMENTO
											FROM SEGUROS.V1SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.AUX_CERTIFICADO}'
											AND TIPO_SEGURADO = '2'";

            return query;
        }
        public string SEGURAVG_NUM_APOL { get; set; }
        public string SEGURAVG_COD_SUBG { get; set; }
        public string SEGURAVG_COD_CLI { get; set; }
        public string SEGURAVG_NUM_CERT { get; set; }
        public string SEGURAVG_DAC_CERT { get; set; }
        public string SEGURAVG_TIPO_SEG { get; set; }
        public string SEGURAVG_NUM_ITEM { get; set; }
        public string SEGURAVG_OCORR_HI { get; set; }
        public string SEGURAVG_EST_CIVIL { get; set; }
        public string SEGURAVG_IDE_SEXO { get; set; }
        public string SEGURAVG_MATRICULA { get; set; }
        public string SEGURAVG_DT_INIVI { get; set; }
        public string SEGURAVG_SIT_REG { get; set; }
        public string SEGURAVG_DT_NASCI { get; set; }
        public string AUX_CERTIFICADO { get; set; }

        public static M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1 Execute(M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1 m_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1)
        {
            var ths = m_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.SEGURAVG_NUM_APOL = result[i++].Value?.ToString();
            dta.SEGURAVG_COD_SUBG = result[i++].Value?.ToString();
            dta.SEGURAVG_COD_CLI = result[i++].Value?.ToString();
            dta.SEGURAVG_NUM_CERT = result[i++].Value?.ToString();
            dta.SEGURAVG_DAC_CERT = result[i++].Value?.ToString();
            dta.SEGURAVG_TIPO_SEG = result[i++].Value?.ToString();
            dta.SEGURAVG_NUM_ITEM = result[i++].Value?.ToString();
            dta.SEGURAVG_OCORR_HI = result[i++].Value?.ToString();
            dta.SEGURAVG_EST_CIVIL = result[i++].Value?.ToString();
            dta.SEGURAVG_IDE_SEXO = result[i++].Value?.ToString();
            dta.SEGURAVG_MATRICULA = result[i++].Value?.ToString();
            dta.SEGURAVG_DT_INIVI = result[i++].Value?.ToString();
            dta.SEGURAVG_SIT_REG = result[i++].Value?.ToString();
            dta.SEGURAVG_DT_NASCI = result[i++].Value?.ToString();
            return dta;
        }

    }
}