using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0141B
{
    public class R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1 : QueryBasis<R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.EMISSAO_DIARIA
            (COD_RELATORIO
            ,NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,DATA_MOVIMENTO
            ,ORGAO_EMISSOR
            ,RAMO_EMISSOR
            ,COD_FONTE
            ,COD_CONGENERE
            ,COD_CORRETOR
            ,SIT_REGISTRO
            ,COD_EMPRESA
            ,TIMESTAMP)
            VALUES
            (:EMISSDIA-COD-RELATORIO
            ,:PARCEHIS-NUM-APOLICE
            ,:PARCEHIS-NUM-ENDOSSO
            ,:PARCEHIS-NUM-PARCELA
            ,:PARCEHIS-DATA-MOVIMENTO
            ,:EMISSDIA-ORGAO-EMISSOR
            ,:ENDOSSOS-RAMO-EMISSOR
            ,:EMISSDIA-COD-FONTE
            ,:APOLCOSS-COD-COSSEGURADORA
            ,:EMISSDIA-COD-CORRETOR
            ,:EMISSDIA-SIT-REGISTRO
            ,:PARCEHIS-COD-EMPRESA:VIND-COD-EMPRESA
            , CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.EMISSAO_DIARIA (COD_RELATORIO ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,ORGAO_EMISSOR ,RAMO_EMISSOR ,COD_FONTE ,COD_CONGENERE ,COD_CORRETOR ,SIT_REGISTRO ,COD_EMPRESA ,TIMESTAMP) VALUES ({FieldThreatment(this.EMISSDIA_COD_RELATORIO)} ,{FieldThreatment(this.PARCEHIS_NUM_APOLICE)} ,{FieldThreatment(this.PARCEHIS_NUM_ENDOSSO)} ,{FieldThreatment(this.PARCEHIS_NUM_PARCELA)} ,{FieldThreatment(this.PARCEHIS_DATA_MOVIMENTO)} ,{FieldThreatment(this.EMISSDIA_ORGAO_EMISSOR)} ,{FieldThreatment(this.ENDOSSOS_RAMO_EMISSOR)} ,{FieldThreatment(this.EMISSDIA_COD_FONTE)} ,{FieldThreatment(this.APOLCOSS_COD_COSSEGURADORA)} ,{FieldThreatment(this.EMISSDIA_COD_CORRETOR)} ,{FieldThreatment(this.EMISSDIA_SIT_REGISTRO)} , {FieldThreatment((this.VIND_COD_EMPRESA?.ToInt() == -1 ? null : this.PARCEHIS_COD_EMPRESA))} , CURRENT TIMESTAMP)";

            return query;
        }
        public string EMISSDIA_COD_RELATORIO { get; set; }
        public string PARCEHIS_NUM_APOLICE { get; set; }
        public string PARCEHIS_NUM_ENDOSSO { get; set; }
        public string PARCEHIS_NUM_PARCELA { get; set; }
        public string PARCEHIS_DATA_MOVIMENTO { get; set; }
        public string EMISSDIA_ORGAO_EMISSOR { get; set; }
        public string ENDOSSOS_RAMO_EMISSOR { get; set; }
        public string EMISSDIA_COD_FONTE { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }
        public string EMISSDIA_COD_CORRETOR { get; set; }
        public string EMISSDIA_SIT_REGISTRO { get; set; }
        public string PARCEHIS_COD_EMPRESA { get; set; }
        public string VIND_COD_EMPRESA { get; set; }

        public static void Execute(R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1 r2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1)
        {
            var ths = r2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2800_00_INSERT_EMISSDIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}