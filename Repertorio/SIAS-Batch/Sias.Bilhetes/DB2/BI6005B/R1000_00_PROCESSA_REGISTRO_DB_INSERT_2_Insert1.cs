using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0ENDOSSO
            (NUM_APOLICE ,
            NRENDOS ,
            CODSUBES ,
            FONTE ,
            NRPROPOS ,
            DATPRO ,
            DATA_LIBERACAO ,
            DTEMIS ,
            NRRCAP ,
            VLRCAP ,
            BCORCAP ,
            AGERCAP ,
            DACRCAP ,
            IDRCAP ,
            BCOCOBR ,
            AGECOBR ,
            DACCOBR ,
            DTINIVIG ,
            DTTERVIG ,
            CDFRACIO ,
            PCENTRAD ,
            PCADICIO ,
            PRESTA1 ,
            QTPARCEL ,
            QTPRESTA ,
            QTITENS ,
            CODTXT ,
            CDACEITA ,
            COD_MOEDA_IMP ,
            COD_MOEDA_PRM ,
            TIPO_ENDOSSO ,
            COD_USUARIO ,
            OCORR_ENDERECO ,
            SITUACAO ,
            DATARCAP ,
            COD_EMPRESA ,
            CORRECAO ,
            ISENTA_CUSTO ,
            TIMESTAMP ,
            DTVENCTO ,
            CFPREFIX ,
            VLCUSEMI ,
            RAMO ,
            CODPRODU)
            VALUES (:V0ENDO-NUM-APOL ,
            :V0ENDO-NRENDOS ,
            :V0ENDO-CODSUBES ,
            :V0ENDO-FONTE ,
            :V0ENDO-NRPROPOS ,
            :V0ENDO-DATPRO ,
            :V0ENDO-DT-LIBER ,
            :V0ENDO-DTEMIS ,
            :V0ENDO-NRRCAP ,
            :V0ENDO-VLRCAP ,
            :V0ENDO-BCORCAP ,
            :V0ENDO-AGERCAP ,
            :V0ENDO-DACRCAP ,
            :V0ENDO-IDRCAP ,
            :V0ENDO-BCOCOBR ,
            :V0ENDO-AGECOBR ,
            :V0ENDO-DACCOBR ,
            :V0ENDO-DTINIVIG ,
            :V0ENDO-DTTERVIG ,
            :V0ENDO-CDFRACIO ,
            :V0ENDO-PCENTRAD ,
            :V0ENDO-PCADICIO ,
            :V0ENDO-PRESTA1 ,
            :V0ENDO-QTPARCEL ,
            :V0ENDO-QTPRESTA ,
            :V0ENDO-QTITENS ,
            :V0ENDO-CODTXT ,
            :V0ENDO-CDACEITA ,
            :V0ENDO-MOEDA-IMP,
            :V0ENDO-MOEDA-PRM,
            :V0ENDO-TIPO-ENDO,
            :V0ENDO-COD-USUAR,
            :V0ENDO-OCORR-END,
            :V0ENDO-SITUACAO ,
            :V0ENDO-DATARCAP:VIND-DATARCAP ,
            :V0ENDO-COD-EMPRESA ,
            :V0ENDO-CORRECAO ,
            :V0ENDO-ISENTA-CST ,
            CURRENT TIMESTAMP ,
            :V0ENDO-DTVENCTO:VIND-DTVENCTO ,
            :V0ENDO-CFPREFIX:VIND-CFPREFIX ,
            :V0ENDO-VLCUSEMI:VIND-VLCUSEMI ,
            :V0ENDO-RAMO ,
            :V0ENDO-CODPRODU)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES ({FieldThreatment(this.V0ENDO_NUM_APOL)} , {FieldThreatment(this.V0ENDO_NRENDOS)} , {FieldThreatment(this.V0ENDO_CODSUBES)} , {FieldThreatment(this.V0ENDO_FONTE)} , {FieldThreatment(this.V0ENDO_NRPROPOS)} , {FieldThreatment(this.V0ENDO_DATPRO)} , {FieldThreatment(this.V0ENDO_DT_LIBER)} , {FieldThreatment(this.V0ENDO_DTEMIS)} , {FieldThreatment(this.V0ENDO_NRRCAP)} , {FieldThreatment(this.V0ENDO_VLRCAP)} , {FieldThreatment(this.V0ENDO_BCORCAP)} , {FieldThreatment(this.V0ENDO_AGERCAP)} , {FieldThreatment(this.V0ENDO_DACRCAP)} , {FieldThreatment(this.V0ENDO_IDRCAP)} , {FieldThreatment(this.V0ENDO_BCOCOBR)} , {FieldThreatment(this.V0ENDO_AGECOBR)} , {FieldThreatment(this.V0ENDO_DACCOBR)} , {FieldThreatment(this.V0ENDO_DTINIVIG)} , {FieldThreatment(this.V0ENDO_DTTERVIG)} , {FieldThreatment(this.V0ENDO_CDFRACIO)} , {FieldThreatment(this.V0ENDO_PCENTRAD)} , {FieldThreatment(this.V0ENDO_PCADICIO)} , {FieldThreatment(this.V0ENDO_PRESTA1)} , {FieldThreatment(this.V0ENDO_QTPARCEL)} , {FieldThreatment(this.V0ENDO_QTPRESTA)} , {FieldThreatment(this.V0ENDO_QTITENS)} , {FieldThreatment(this.V0ENDO_CODTXT)} , {FieldThreatment(this.V0ENDO_CDACEITA)} , {FieldThreatment(this.V0ENDO_MOEDA_IMP)}, {FieldThreatment(this.V0ENDO_MOEDA_PRM)}, {FieldThreatment(this.V0ENDO_TIPO_ENDO)}, {FieldThreatment(this.V0ENDO_COD_USUAR)}, {FieldThreatment(this.V0ENDO_OCORR_END)}, {FieldThreatment(this.V0ENDO_SITUACAO)} ,  {FieldThreatment((this.VIND_DATARCAP?.ToInt() == -1 ? null : this.V0ENDO_DATARCAP))} , {FieldThreatment(this.V0ENDO_COD_EMPRESA)} , {FieldThreatment(this.V0ENDO_CORRECAO)} , {FieldThreatment(this.V0ENDO_ISENTA_CST)} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_DTVENCTO?.ToInt() == -1 ? null : this.V0ENDO_DTVENCTO))} ,  {FieldThreatment((this.VIND_CFPREFIX?.ToInt() == -1 ? null : this.V0ENDO_CFPREFIX))} ,  {FieldThreatment((this.VIND_VLCUSEMI?.ToInt() == -1 ? null : this.V0ENDO_VLCUSEMI))} , {FieldThreatment(this.V0ENDO_RAMO)} , {FieldThreatment(this.V0ENDO_CODPRODU)})";

            return query;
        }
        public string V0ENDO_NUM_APOL { get; set; }
        public string V0ENDO_NRENDOS { get; set; }
        public string V0ENDO_CODSUBES { get; set; }
        public string V0ENDO_FONTE { get; set; }
        public string V0ENDO_NRPROPOS { get; set; }
        public string V0ENDO_DATPRO { get; set; }
        public string V0ENDO_DT_LIBER { get; set; }
        public string V0ENDO_DTEMIS { get; set; }
        public string V0ENDO_NRRCAP { get; set; }
        public string V0ENDO_VLRCAP { get; set; }
        public string V0ENDO_BCORCAP { get; set; }
        public string V0ENDO_AGERCAP { get; set; }
        public string V0ENDO_DACRCAP { get; set; }
        public string V0ENDO_IDRCAP { get; set; }
        public string V0ENDO_BCOCOBR { get; set; }
        public string V0ENDO_AGECOBR { get; set; }
        public string V0ENDO_DACCOBR { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V0ENDO_DTTERVIG { get; set; }
        public string V0ENDO_CDFRACIO { get; set; }
        public string V0ENDO_PCENTRAD { get; set; }
        public string V0ENDO_PCADICIO { get; set; }
        public string V0ENDO_PRESTA1 { get; set; }
        public string V0ENDO_QTPARCEL { get; set; }
        public string V0ENDO_QTPRESTA { get; set; }
        public string V0ENDO_QTITENS { get; set; }
        public string V0ENDO_CODTXT { get; set; }
        public string V0ENDO_CDACEITA { get; set; }
        public string V0ENDO_MOEDA_IMP { get; set; }
        public string V0ENDO_MOEDA_PRM { get; set; }
        public string V0ENDO_TIPO_ENDO { get; set; }
        public string V0ENDO_COD_USUAR { get; set; }
        public string V0ENDO_OCORR_END { get; set; }
        public string V0ENDO_SITUACAO { get; set; }
        public string V0ENDO_DATARCAP { get; set; }
        public string VIND_DATARCAP { get; set; }
        public string V0ENDO_COD_EMPRESA { get; set; }
        public string V0ENDO_CORRECAO { get; set; }
        public string V0ENDO_ISENTA_CST { get; set; }
        public string V0ENDO_DTVENCTO { get; set; }
        public string VIND_DTVENCTO { get; set; }
        public string V0ENDO_CFPREFIX { get; set; }
        public string VIND_CFPREFIX { get; set; }
        public string V0ENDO_VLCUSEMI { get; set; }
        public string VIND_VLCUSEMI { get; set; }
        public string V0ENDO_RAMO { get; set; }
        public string V0ENDO_CODPRODU { get; set; }

        public static void Execute(R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1 r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}