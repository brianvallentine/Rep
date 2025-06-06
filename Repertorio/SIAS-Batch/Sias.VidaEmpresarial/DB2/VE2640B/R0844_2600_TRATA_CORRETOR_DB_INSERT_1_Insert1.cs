using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1 : QueryBasis<R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.APOLICE_CORRETOR
            ( NUM_APOLICE ,
            RAMO_COBERTURA ,
            MODALI_COBERTURA ,
            COD_CORRETOR ,
            COD_SUBGRUPO ,
            DATA_INIVIGENCIA ,
            DATA_TERVIGENCIA ,
            PCT_PART_CORRETOR ,
            PCT_COM_CORRETOR ,
            TIPO_COMISSAO ,
            IND_CORRETOR_PRIN ,
            COD_EMPRESA ,
            TIMESTAMP ,
            COD_USUARIO )
            VALUES
            ( :APOLICOR-NUM-APOLICE ,
            :APOLICOR-RAMO-COBERTURA ,
            :APOLICOR-MODALI-COBERTURA ,
            :APOLICOR-COD-CORRETOR ,
            :APOLICOR-COD-SUBGRUPO ,
            :APOLICOR-DATA-INIVIGENCIA ,
            :APOLICOR-DATA-TERVIGENCIA ,
            :APOLICOR-PCT-PART-CORRETOR ,
            :APOLICOR-PCT-COM-CORRETOR ,
            :APOLICOR-TIPO-COMISSAO ,
            :APOLICOR-IND-CORRETOR-PRIN ,
            :APOLICOR-COD-EMPRESA ,
            CURRENT TIMESTAMP ,
            :APOLICOR-COD-USUARIO )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.APOLICE_CORRETOR ( NUM_APOLICE , RAMO_COBERTURA , MODALI_COBERTURA , COD_CORRETOR , COD_SUBGRUPO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , PCT_PART_CORRETOR , PCT_COM_CORRETOR , TIPO_COMISSAO , IND_CORRETOR_PRIN , COD_EMPRESA , TIMESTAMP , COD_USUARIO ) VALUES ( {FieldThreatment(this.APOLICOR_NUM_APOLICE)} , {FieldThreatment(this.APOLICOR_RAMO_COBERTURA)} , {FieldThreatment(this.APOLICOR_MODALI_COBERTURA)} , {FieldThreatment(this.APOLICOR_COD_CORRETOR)} , {FieldThreatment(this.APOLICOR_COD_SUBGRUPO)} , {FieldThreatment(this.APOLICOR_DATA_INIVIGENCIA)} , {FieldThreatment(this.APOLICOR_DATA_TERVIGENCIA)} , {FieldThreatment(this.APOLICOR_PCT_PART_CORRETOR)} , {FieldThreatment(this.APOLICOR_PCT_COM_CORRETOR)} , {FieldThreatment(this.APOLICOR_TIPO_COMISSAO)} , {FieldThreatment(this.APOLICOR_IND_CORRETOR_PRIN)} , {FieldThreatment(this.APOLICOR_COD_EMPRESA)} , CURRENT TIMESTAMP , {FieldThreatment(this.APOLICOR_COD_USUARIO)} )";

            return query;
        }
        public string APOLICOR_NUM_APOLICE { get; set; }
        public string APOLICOR_RAMO_COBERTURA { get; set; }
        public string APOLICOR_MODALI_COBERTURA { get; set; }
        public string APOLICOR_COD_CORRETOR { get; set; }
        public string APOLICOR_COD_SUBGRUPO { get; set; }
        public string APOLICOR_DATA_INIVIGENCIA { get; set; }
        public string APOLICOR_DATA_TERVIGENCIA { get; set; }
        public string APOLICOR_PCT_PART_CORRETOR { get; set; }
        public string APOLICOR_PCT_COM_CORRETOR { get; set; }
        public string APOLICOR_TIPO_COMISSAO { get; set; }
        public string APOLICOR_IND_CORRETOR_PRIN { get; set; }
        public string APOLICOR_COD_EMPRESA { get; set; }
        public string APOLICOR_COD_USUARIO { get; set; }

        public static void Execute(R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1 r0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1)
        {
            var ths = r0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0844_2600_TRATA_CORRETOR_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}