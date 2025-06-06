using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLICE
            (CODCLIEN ,
            NUM_APOLICE ,
            NUM_ITEM ,
            MODALIDA ,
            ORGAO ,
            RAMO ,
            NUM_APOL_ANTERIOR ,
            NUMBIL ,
            TIPSGU ,
            TIPAPO ,
            TIPCALC ,
            PODPUBL ,
            NUM_ATA ,
            ANO_ATA ,
            IDEMAN ,
            PCDESCON ,
            PCIOCC ,
            TPCOSCED ,
            QTCOSSEG ,
            PCTCED ,
            DATA_SORTEIO ,
            COD_EMPRESA ,
            TIMESTAMP ,
            CODPRODU ,
            TPCORRET)
            VALUES (:V0APOL-CODCLIEN ,
            :V0APOL-NUM-APOL ,
            :V0APOL-NUM-ITEM ,
            :V0APOL-MODALIDA ,
            :V0APOL-ORGAO ,
            :V0APOL-RAMO ,
            :V0APOL-NUM-APO-ANT ,
            :V0APOL-NUMBIL ,
            :V0APOL-TIPSGU ,
            :V0APOL-TIPAPO ,
            :V0APOL-TIPCALC ,
            :V0APOL-PODPUBL ,
            :V0APOL-NUM-ATA ,
            :V0APOL-ANO-ATA ,
            :V0APOL-IDEMAN ,
            :V0APOL-PCDESCON ,
            :V0APOL-PCIOCC ,
            :V0APOL-TPCOSCED ,
            :V0APOL-QTCOSSEG ,
            :V0APOL-PCTCED ,
            NULL ,
            :V0APOL-COD-EMPRESA ,
            CURRENT TIMESTAMP ,
            :V0APOL-CODPRODU ,
            :V0APOL-TPCORRET)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES ({FieldThreatment(this.V0APOL_CODCLIEN)} , {FieldThreatment(this.V0APOL_NUM_APOL)} , {FieldThreatment(this.V0APOL_NUM_ITEM)} , {FieldThreatment(this.V0APOL_MODALIDA)} , {FieldThreatment(this.V0APOL_ORGAO)} , {FieldThreatment(this.V0APOL_RAMO)} , {FieldThreatment(this.V0APOL_NUM_APO_ANT)} , {FieldThreatment(this.V0APOL_NUMBIL)} , {FieldThreatment(this.V0APOL_TIPSGU)} , {FieldThreatment(this.V0APOL_TIPAPO)} , {FieldThreatment(this.V0APOL_TIPCALC)} , {FieldThreatment(this.V0APOL_PODPUBL)} , {FieldThreatment(this.V0APOL_NUM_ATA)} , {FieldThreatment(this.V0APOL_ANO_ATA)} , {FieldThreatment(this.V0APOL_IDEMAN)} , {FieldThreatment(this.V0APOL_PCDESCON)} , {FieldThreatment(this.V0APOL_PCIOCC)} , {FieldThreatment(this.V0APOL_TPCOSCED)} , {FieldThreatment(this.V0APOL_QTCOSSEG)} , {FieldThreatment(this.V0APOL_PCTCED)} , NULL , {FieldThreatment(this.V0APOL_COD_EMPRESA)} , CURRENT TIMESTAMP , {FieldThreatment(this.V0APOL_CODPRODU)} , {FieldThreatment(this.V0APOL_TPCORRET)})";

            return query;
        }
        public string V0APOL_CODCLIEN { get; set; }
        public string V0APOL_NUM_APOL { get; set; }
        public string V0APOL_NUM_ITEM { get; set; }
        public string V0APOL_MODALIDA { get; set; }
        public string V0APOL_ORGAO { get; set; }
        public string V0APOL_RAMO { get; set; }
        public string V0APOL_NUM_APO_ANT { get; set; }
        public string V0APOL_NUMBIL { get; set; }
        public string V0APOL_TIPSGU { get; set; }
        public string V0APOL_TIPAPO { get; set; }
        public string V0APOL_TIPCALC { get; set; }
        public string V0APOL_PODPUBL { get; set; }
        public string V0APOL_NUM_ATA { get; set; }
        public string V0APOL_ANO_ATA { get; set; }
        public string V0APOL_IDEMAN { get; set; }
        public string V0APOL_PCDESCON { get; set; }
        public string V0APOL_PCIOCC { get; set; }
        public string V0APOL_TPCOSCED { get; set; }
        public string V0APOL_QTCOSSEG { get; set; }
        public string V0APOL_PCTCED { get; set; }
        public string V0APOL_COD_EMPRESA { get; set; }
        public string V0APOL_CODPRODU { get; set; }
        public string V0APOL_TPCORRET { get; set; }

        public static void Execute(R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}