using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 : QueryBasis<R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_APOLICE ,
            A.NRENDOS ,
            A.NRPARCEL ,
            A.DACPARC ,
            A.FONTE ,
            A.NRTIT ,
            A.PRM_TARIFARIO_IX ,
            A.VAL_DESCONTO_IX ,
            A.OTNPRLIQ ,
            A.OTNADFRA ,
            A.OTNCUSTO ,
            A.OTNIOF ,
            A.OTNTOTAL ,
            A.OCORHIST ,
            A.QTDDOC ,
            A.SITUACAO
            INTO :V1PARC-NUM-APOL ,
            :V1PARC-NRENDOS ,
            :V1PARC-NRPARCEL ,
            :V1PARC-DACPARC ,
            :V1PARC-FONTE ,
            :V1PARC-NRTIT ,
            :V1PARC-PRM-TAR ,
            :V1PARC-VAL-DES ,
            :V1PARC-OTNPRLIQ ,
            :V1PARC-OTNADFRA ,
            :V1PARC-OTNCUSTO ,
            :V1PARC-OTNIOF ,
            :V1PARC-OTNTOTAL ,
            :V1PARC-OCORHIST ,
            :V1PARC-QTDDOC ,
            :V1PARC-SITUACAO
            FROM SEGUROS.V1PARCELA A,
            SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
            WHERE B.NUM_TITULO = :V1MCOB-NRTIT
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.NUM_ENDOSSO = A.NRENDOS
            AND B.NUM_PARCELA = A.NRPARCEL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_APOLICE 
							,
											A.NRENDOS 
							,
											A.NRPARCEL 
							,
											A.DACPARC 
							,
											A.FONTE 
							,
											A.NRTIT 
							,
											A.PRM_TARIFARIO_IX 
							,
											A.VAL_DESCONTO_IX 
							,
											A.OTNPRLIQ 
							,
											A.OTNADFRA 
							,
											A.OTNCUSTO 
							,
											A.OTNIOF 
							,
											A.OTNTOTAL 
							,
											A.OCORHIST 
							,
											A.QTDDOC 
							,
											A.SITUACAO
											FROM SEGUROS.V1PARCELA A
							,
											SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B
											WHERE B.NUM_TITULO = '{this.V1MCOB_NRTIT}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.NUM_ENDOSSO = A.NRENDOS
											AND B.NUM_PARCELA = A.NRPARCEL
											WITH UR";

            return query;
        }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRENDOS { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_DACPARC { get; set; }
        public string V1PARC_FONTE { get; set; }
        public string V1PARC_NRTIT { get; set; }
        public string V1PARC_PRM_TAR { get; set; }
        public string V1PARC_VAL_DES { get; set; }
        public string V1PARC_OTNPRLIQ { get; set; }
        public string V1PARC_OTNADFRA { get; set; }
        public string V1PARC_OTNCUSTO { get; set; }
        public string V1PARC_OTNIOF { get; set; }
        public string V1PARC_OTNTOTAL { get; set; }
        public string V1PARC_OCORHIST { get; set; }
        public string V1PARC_QTDDOC { get; set; }
        public string V1PARC_SITUACAO { get; set; }
        public string V1MCOB_NRTIT { get; set; }

        public static R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 Execute(R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 r3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3220_00_SELECT_V1PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1PARC_NUM_APOL = result[i++].Value?.ToString();
            dta.V1PARC_NRENDOS = result[i++].Value?.ToString();
            dta.V1PARC_NRPARCEL = result[i++].Value?.ToString();
            dta.V1PARC_DACPARC = result[i++].Value?.ToString();
            dta.V1PARC_FONTE = result[i++].Value?.ToString();
            dta.V1PARC_NRTIT = result[i++].Value?.ToString();
            dta.V1PARC_PRM_TAR = result[i++].Value?.ToString();
            dta.V1PARC_VAL_DES = result[i++].Value?.ToString();
            dta.V1PARC_OTNPRLIQ = result[i++].Value?.ToString();
            dta.V1PARC_OTNADFRA = result[i++].Value?.ToString();
            dta.V1PARC_OTNCUSTO = result[i++].Value?.ToString();
            dta.V1PARC_OTNIOF = result[i++].Value?.ToString();
            dta.V1PARC_OTNTOTAL = result[i++].Value?.ToString();
            dta.V1PARC_OCORHIST = result[i++].Value?.ToString();
            dta.V1PARC_QTDDOC = result[i++].Value?.ToString();
            dta.V1PARC_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}